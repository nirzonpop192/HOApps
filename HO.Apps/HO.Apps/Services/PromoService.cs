using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Messaging;
using HO.Apps.Models;
using HO.Apps.Services;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(PromoService))]
namespace HO.Apps.Services
{
    public class PromoService : IPromoService
    {
        private readonly IGlobalOptionService _globalOptionService;
        private readonly ISoftwareService _softwareService;
        private readonly ISponsorService _sponsorService;
        private readonly ILogService _logService;
        public PromoService()
        {
            _globalOptionService = DependencyService.Get<IGlobalOptionService>();
            _softwareService = DependencyService.Get<ISoftwareService>();
            _sponsorService = DependencyService.Get<ISponsorService>();
            _logService = DependencyService.Get<ILogService>();
        }
        public void CheckSponsor()
        {
            string registrationId = _globalOptionService.GetOptionContent(SettingConstant.RegistrationKey);
            string promoCode = _globalOptionService.GetOptionContent(SettingConstant.PromoCodeKey);

            //we have sponsor info from the database
            string sponsorId = _globalOptionService.GetOptionContent(SettingConstant.SponsorIdKey);

            // now compare sponsorid with the web sponsor id
            string newSponsorId = GetSponsorId(registrationId, promoCode);

            // If they ( web and databse) match then download new sponsorinfo
            // There is a good change both of them are null. 
            // a new user who couldn't connect to the web
            if (sponsorId == null && newSponsorId == null)
            {
                _sponsorService.SaveSponsor(sponsorZip: null);
                return;
            }

            // existing sponsor user who couldn't connect to the web
            if (sponsorId != null && newSponsorId == null)
            {
                // stay with current one and exit
                return;
            }

            if (sponsorId != newSponsorId)
            {
                _sponsorService.SaveSponsor(GetSponsorData());

                // Update New SponsorId
                _globalOptionService.SetOption(SettingConstant.SponsorIdKey, newSponsorId);
            }
        }

        public void CommonSplashData(SplashDefinition splashDefinition)
        {
            if (splashDefinition != null)
            {
                if (!splashDefinition.ImageId.IsEmpty())
                    _globalOptionService.SetOption(SettingConstant.SplashImageIDKey, splashDefinition.ImageId);
                if (splashDefinition.AgentXMLData != null)
                {
                    try
                    {
                        var innerXml = JsonConvert.SerializeObject(splashDefinition.AgentXMLData.PROMOINFO);
                        _globalOptionService.SetOption(SettingConstant.AgentXMLDataKey, innerXml);
                    }
                    catch (Exception ex)
                    {
                        _logService.LogException(ex);
                    }
                }

                // Show message from the server
                try
                {
                    if (splashDefinition.MessageText != null)
                    {
                        _globalOptionService.SetOption(SettingConstant.MessageFromServerKey, splashDefinition.MessageText);
                    }
                    else
                    {
                        _globalOptionService.SetOption(SettingConstant.MessageFromServerKey, string.Empty);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public string GetImageId(string registrationId, string promoCode)
        {
            string result = string.Empty;
            try
            {
                result = _softwareService.GetImageId(registrationId, promoCode);
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        public SplashDefinition GetSplashDefData()
        {
            SplashDefinition result = default(SplashDefinition);
            try
            {
                string registrationId = _globalOptionService.GetOptionContent(SettingConstant.RegistrationKey);
                string promoCode = _globalOptionService.GetOptionContent(SettingConstant.PromoCodeKey);
                result = _softwareService.AgentSplashDefData(registrationId, promoCode);
                if (result != null && !result.SplashImage.IsEmpty())
                {
                    result.SplashImage = result.SplashImage.ConvertToImageUrl();
                }
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }

            return result;
        }

        public string GetSplashImage()
        {
            string result = string.Empty;
            string splashImageId, newSplashImageId = string.Empty;
            string registrationId = _globalOptionService.GetOptionContent(SettingConstant.RegistrationKey);

            switch (registrationId)
            {
                case null:
                case "":
                    registrationId = "-1";
                    _globalOptionService.SetOption(SettingConstant.RegistrationKey, registrationId);
                    break;
                case "-1":
                    registrationId = "0";
                    _globalOptionService.SetOption(SettingConstant.RegistrationKey, registrationId);
                    break;
            }

            string promoCode = _globalOptionService.GetOptionContent(SettingConstant.PromoCodeKey);

            splashImageId = _globalOptionService.GetOptionContent(SettingConstant.SplashImageIDKey);
            newSplashImageId = GetImageId(registrationId, promoCode);

            if (!newSplashImageId.Equals(splashImageId, StringComparison.CurrentCulture))
            {
                //Download the splash
                SplashDefinition splashDefinition = GetSplashDefData();
                if (splashDefinition != null)
                {
                    if (!splashDefinition.SplashImage.IsEmpty())
                    {
                        _globalOptionService.SetOption(SettingConstant.SplashPictureKey, splashDefinition.SplashImage);
                        result = splashDefinition.SplashImage;
                    }

                    CommonSplashData(splashDefinition);

                    // Update New Splash Image Id
                    _globalOptionService.SetOption(SettingConstant.SplashImageIDKey, newSplashImageId);
                }
            }

            if (result.IsEmpty())
            {
                //Retrieve the existing splash
                result = _globalOptionService.GetOptionContent(SettingConstant.SplashPictureKey);
            }

            return result;
        }

        public SponsorZip GetSponsorData()
        {
            SponsorZip result = default(SponsorZip);
            try
            {
                string registrationId = _globalOptionService.GetOptionContent(SettingConstant.RegistrationKey);
                string promoCode = _globalOptionService.GetOptionContent(SettingConstant.PromoCodeKey);

                result = _softwareService.GetSponsorZipFiles(registrationId, promoCode);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }

            return result;
        }

        public string GetSponsorId(string registrationId, string promoCode)
        {
            string result = null;

            try
            {
                string[] sponsors = _softwareService.GetSponsorIds(registrationId, promoCode);
                result = sponsors.FirstOrDefault(); // at this moment only take the first group
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }

            return result;
        }

        public bool IsPromoCodeValid(string promoCode)
        {
            return _softwareService.IsValidPromoCode(promoCode);
        }

        public bool IsRegistrationIdValid(string registrationId)
        {
            bool result = false;
            string Promocode = _globalOptionService.GetOption(SettingConstant.PromoCodeKey).OptionValue;

            try
            {
                var response = _softwareService.IsRegistrationKeyValid(registrationId, Promocode);

                if (response != null && !response.ImageUrl.IsEmpty())
                {
                    _globalOptionService.SetOption(SettingConstant.RegistrationKey, registrationId);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Registration Failed!", ex.Message, "Ok");
            }

            return result;
        }

        public bool RegisterMember(RegistrationRequest requst)
        {
            bool result = false;
            try
            {
                RegistrationResponse response = _softwareService.MemberRegistration(requst);
                Debug.WriteLine(response.RegistrationID);

                if (response.RegistrationID.IsEmpty()
                    || (string.Compare(response.RegistrationID, "0") == 0))
                {
                    // registraton failed
                    throw new Exception(response.StatusText);
                }

                // save the data and set return as true
                _globalOptionService.SetOption(SettingConstant.RegistrationKey, response.RegistrationID);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void UpdatePromo()
        {
            //TODO: download new promo stuff
            SplashDefinition splashDef
                 = GetSplashDefData();

            if (splashDef != null && splashDef.ValidPromoCode)
            {
                string Promocode = _globalOptionService.GetOptionContent(SettingConstant.PromoCodeKey);
                CommonSplashData(splashDef);
                _globalOptionService.SetOption(SettingConstant.SplashPictureKey, splashDef.SplashImage);
            }

            //Andy
            _sponsorService.SaveSponsor(GetSponsorData());
        }
    }
}
