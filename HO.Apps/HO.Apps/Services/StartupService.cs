using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Localization;
using HO.Apps.Models;
using HO.Apps.Services;
using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(StartupService))]
namespace HO.Apps.Services
{
    public class StartupService : IStartupService
    {
        private readonly ICrossFileService _crossFileService;
        private readonly IDataService _dataService;
        private readonly IPromoService _promoService;
        private readonly IGlobalOptionService _globalOptionService;
        //private readonly ISponsorService _sponsorService;
        private readonly ILogService _logService;

        public StartupService()
        {
            _crossFileService = DependencyService.Get<ICrossFileService>();
            _dataService = DependencyService.Get<IDataService>();
            _promoService = DependencyService.Get<IPromoService>();
            _globalOptionService = DependencyService.Get<IGlobalOptionService>();
            _logService = DependencyService.Get<ILogService>();
        }

        public bool IsDigitalIDDirectoryExists()
        {
            string path = Path.Combine(_crossFileService.GetDefaultDirectory(),
                                ApplicationSettingsConstant.DatabaseDirectory,
                                ApplicationSettingsConstant.DatabaseName);
            return _crossFileService.IsFileExists(path);
        }

        public bool IsFirstRunComplete()
        {
            bool result = false;
            var content = _globalOptionService.GetOptionContent(SettingConstant.FirstRunCompleteKey);
            if (!content.IsEmpty())
                result = bool.Parse(content);

            return result;
        }

        public void ResetApplication()
        {

        }

        public void FreshInstallationTasks(string promoCode)
        {
            string installerFileName = ApplicationSettingsConstant.InstallerFileName;
            _logService.Log("Begin StartupService.DoFirstRunTasks", installerFileName);
            _logService.Log("Creating Directory Structure", installerFileName);
            _dataService.CreateDataDirectoryStructure();
            _logService.Log("Creating Database and Tables", installerFileName);
            _dataService.CreateDatabase();
            _logService.Log(string.Format("{0} {1}", "Storing Promo Code", promoCode), installerFileName);
            _globalOptionService.EnsureGlobalOptionExists(SettingConstant.PromoCodeKey, promoCode);
            _logService.Log("Initializing Registration Id", installerFileName);
            _globalOptionService.EnsureGlobalOptionExists(SettingConstant.RegistrationKey, "-1");
            _logService.Log("Initializing Machine", installerFileName);
            _globalOptionService.EnsureGlobalOptionExists(SettingConstant.MachineKey, "");
            _logService.Log("Upldating Splash Screen from the Imagery Concepts Website", installerFileName);
            _promoService.UpdatePromo();
            _logService.Log("Setting UI Culture", installerFileName);
            InitializeCulture();
        }

        private void InitializeCulture()
        {
            /* if we were targeting Windows Phone, we'd want to include the next line. */
            // if (Device.OS != TargetPlatform.WinPhone) 
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            // Get user's culture preference

            GlobalOption culture
                = _globalOptionService.GetOption(SettingConstant.MachineKey);

            // Get global default preference            

            if (culture == null)
            {
                // check for culture text file

                try
                {
                    //string _culturefileName = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "culture.txt");
                    //if (System.IO.File.Exists(_culturefileName))
                    //{
                    //    string _culName = System.IO.File.ReadAllText(_culturefileName);
                    //    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(_culName);
                    //    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(_culName);
                    //    //
                    //    OptionManager.SetGlobalOptionValue("Culture", _culName);
                    //    //System.IO.File.Delete(_culturefileName);

                    //}



                    //else // leave whatever we have in the Current Culture
                    //{ //set the current one

                    //}
                }
                catch (System.Exception e)
                {
                    _logService.LogException(e);
                }

            }

            _logService.Log("Copying OEM Files", ApplicationSettingsConstant.InstallerFileName);


            _logService.Log("Setting FirstRunComplete Flag...");

            _globalOptionService.SetOption(SettingConstant.FirstRunCompleteKey, "true");

            // Set the date in USA standard
            IFormatProvider dtculture = new CultureInfo("en-US");

            string dt = DateTime.UtcNow.ToString(dtculture);
            _globalOptionService.SetOption(SettingConstant.DateInstalledKey, dt); // added : July 4th, 2008
            _logService.Log(string.Format("{0} {1}", "End StarupManager.DoFirstRunTasks.", dt), ApplicationSettingsConstant.InstallerFileName);

        }

        private void AddMachineSignature()
        {
            _logService.Log("Initializing Machine");
            var platform = "";
            var deviceType = "";
            switch (Device.OS)
            {
                case TargetPlatform.Other:
                    platform = "Undefined Platform";
                    break;
                case TargetPlatform.iOS:
                    platform = "Apple iOS OS";
                    break;
                case TargetPlatform.Android:
                    platform = "Google Android OS";
                    break;
                case TargetPlatform.WinPhone:
                    platform = "Microsoft WindowsPhone OS";
                    break;
                case TargetPlatform.Windows:
                    platform = "Windows Platform";
                    break;
            }

            switch (Device.Idiom)
            {
                case TargetIdiom.Unsupported:
                    deviceType = "Unsupported";
                    break;
                case TargetIdiom.Phone:
                    deviceType = "Phone";
                    break;
                case TargetIdiom.Tablet:
                    deviceType = "Tablet";
                    break;
                case TargetIdiom.Desktop:
                    deviceType = "Desktop";
                    break;
            }

            var machineSignature = $"{platform} {deviceType}";
        }

        public void InilizeApplication()
        {
            throw new NotImplementedException();
        }

        public string GetAlternativeDataPath()
        {
            string altLocation = string.Empty;
            string baseDirectory = _crossFileService.GetApplicationDataDirectory();
            string directoryLocation = Path.Combine(baseDirectory, ApplicationSettingsConstant.RootDirectory);
            string dataPath = Path.Combine(directoryLocation, ApplicationSettingsConstant.DataLocationiFile);

            if (_crossFileService.IsFileExists(dataPath))
            {
                altLocation = _crossFileService.Load(dataPath);
                if (!altLocation.EndsWith("Imagery Concepts, LLC"))
                {
                    altLocation = Path.Combine(altLocation, "Imagery Concepts, LLC");
                }
                if (!altLocation.EndsWith("Home Organizer 4"))
                {
                    altLocation = Path.Combine(altLocation, "Home Organizer 4");
                }
            }

            return altLocation;
        }

        public bool CheckForRegistration()
        {
            bool result = true;
            try
            {
                string registrationId = _globalOptionService.GetOption(SettingConstant.RegistrationKey).OptionValue;
                if (registrationId == "-1" || registrationId == "0") //not registered yet
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }

            return result;
        }

        public void AddRevisionCode()
        {
            try
            {
                _globalOptionService.SetOption(SettingConstant.RevisionCodeKey, Settings.RevisionCode);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }
        }

        public void InitializeDefaultSettings()
        {
            // Language
            Settings.InitialLanguage = SettingConstant.InitialLanguage;

            // Imagery Concept Site
            Settings.ImageryConceptSite = SettingConstant.ImageryConceptSite;

            // Revision Code
            Settings.RevisionCode = SettingConstant.RevisionCode;

            // Splash Screen
            Settings.IsSplashShown = false;
        }
    }
}
