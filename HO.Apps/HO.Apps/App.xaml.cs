
using HO.Apps.Contracts;
using HO.Apps.Controls.Pages;
using HO.Apps.Localization;
using HO.Apps.Pages.Installation;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HO.Apps
{
    public partial class App : Application
    {
        public static bool IsWindows10 { get; set; }
        static Application app;
        private readonly IStartupService _startupService;
        private readonly ICrossFileService CrossFileService;
        private readonly IGlobalOptionService GlobalOptionService;
        private readonly ILogService LogService;
        public static Application CurrentApp
        {
            get { return app; }
        }

        public App()
        {
            InitializeComponent();
            app = this;
            _startupService = DependencyService.Get<IStartupService>();
            CrossFileService = DependencyService.Get<ICrossFileService>();
            GlobalOptionService = DependencyService.Get<IGlobalOptionService>();
            LogService = DependencyService.Get<ILogService>();

            // Initialize Default Settings
            _startupService.InitializeDefaultSettings();

            // Initialize Culture
            /* if we were targeting Windows Phone, we'd want to include the next line. */
            // if (Device.OS != TargetPlatform.WinPhone) 
            TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            // Proceed To Main Page
            MainPage = InitializeAppliction();
        }


        private Page InitializeAppliction()
        {
            Page result = null;
            if (!_startupService.IsFirstRunComplete())
            {
                result = new PromoCodePage();
                return result;
            }


            // Add Revision Code to Database
            _startupService.AddRevisionCode();

            // Check For Registration
            if (!_startupService.CheckForRegistration())
            {
                result = new InstallationPage();
                return result;
            }

            // check for OEM reminder


            // check for setup file on the desktop and Twain

            // Load Theme

            // Goto Main
            result = new HOPage();
            return result;
        }

        public static void GoToRoot()
        {
            //if (Device.OS == TargetPlatform.iOS)
            //{
            //    CurrentApp.MainPage = new HOTabPage();
            //}
            //else
            //{
            //    CurrentApp.MainPage = new HOPage();
            //}

            CurrentApp.MainPage = new HOPage();
        }

        public static async Task ExecuteIfConnected(Func<Task> actionToExecuteIfConnected)
        {
            if (IsConnected)
            {
                await actionToExecuteIfConnected();
            }
            else
            {
                await ShowNetworkConnectionAlert();
            }
        }

        static async Task ShowNetworkConnectionAlert()
        {
            await CurrentApp.MainPage.DisplayAlert(
                TextResources.NetworkConnection_Alert_Title,
                TextResources.NetworkConnection_Alert_Message,
                TextResources.NetworkConnection_Alert_Confirm);
        }

        static void ShowMessage()
        {
            CurrentApp.MainPage.DisplayAlert("Network Info", "No internet connection found!", "Ok");
        }

        public static bool IsConnected
        {
            get { return CrossConnectivity.Current.IsConnected; }
            //get { return true; }
        }

        public static int AnimationSpeed = 250;

        public static bool IsSplashShown
        {
            get { return Helpers.Settings.IsSplashShown; }
            set { Helpers.Settings.IsSplashShown = value; }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
