using HO.Apps.Contracts;
using HO.Apps.Controls.Pages;
using HO.Apps.Helpers;
using HO.Apps.Pages.Installation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HO.Apps.ViewModels.Installation
{
    public class PromoCodePageViewModel : BaseViewModel
    {
        private readonly IApplicationService _applicationService;
        private readonly IStartupService _startupService;
        private readonly ISoftwareService _softwareService;
        private readonly IGlobalOptionService _globalOptionService;
        private readonly IThemeService _themeService;
        private readonly ILogService _logService;
        private HOPage Root;
        public PromoCodePageViewModel(INavigation navigation = null, HOPage root = null)
            : base(navigation)
        {
            _applicationService = DependencyService.Get<IApplicationService>();
            _startupService = DependencyService.Get<IStartupService>();
            _softwareService = DependencyService.Get<ISoftwareService>();
            _globalOptionService = DependencyService.Get<IGlobalOptionService>();
            _themeService = DependencyService.Get<IThemeService>();
            _logService = DependencyService.Get<ILogService>();
            Root = root;
#if DEBUG
            PromoCode = "106-19522-1";
#endif
        }


        string _logo;
        public int TryCounter { get; set; } = 0;
        public string Logo
        {
            get { return _logo; }
            set { Set(ref _logo, value); }
        }

        bool _isPresentingPromoCodeUI;
        public bool IsPresentingPromoCodeUI
        {
            get { return _isPresentingPromoCodeUI; }
            set { Set(ref _isPresentingPromoCodeUI, value); }
        }



        Command _checkPromoCodeCommand;
        Command _closeCommand;

        public Command CloseCommand
        {
            get
            {
                return _closeCommand ??
                    (_closeCommand = new Command(ExecuteCloseCommand));
            }
        }

        private void ExecuteCloseCommand()
        {
            _applicationService.Terminate();
        }

        public Command CheckPromoCodeCommand
        {
            get
            {
                return _checkPromoCodeCommand ??
                    (_checkPromoCodeCommand = new Command(async () => await ExecuteCheckPromoCodeCommandAsync()));
            }
        }

        async Task ExecuteCheckPromoCodeCommandAsync()
        {
            try
            {
                if (App.IsConnected)
                {
                    if (!CheckInputs())
                    {
                        IsValid = false;
                        return;
                    }

                    IsValid = true;

                    // trigger the activity indicator through the IsPresentingPromoCodeUI property on the ViewModel
                    IsPresentingPromoCodeUI = true;

                    if (await Authenticate())
                    {
                        IsValid = true;
                        Message = string.Empty;
                        InitializeAppliction();
                    }
                    else
                    {
                        IsValid = false;
                        Message = "Invalid promo code.";
                    }
                }
                else
                {
                    string message = "Your must connect to the Internet!\nIf you believe you are connected, please check your firewall and try again after 2 minutes";
                    var result = await Application.Current.MainPage.DisplayAlert("Network Connectivity", message, "Retry", "Cancel");
                }
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
                _applicationService.Terminate();
            }

            finally
            {
                IsPresentingPromoCodeUI = false;
            }
        }

        private bool CheckInputs()
        {
            bool result = true;
            Message = string.Empty;
            if (PromoCode.IsEmpty())
            {
                IsValid = false;
                Message = "Enter your promo code.";
                result = false;
            }

            if (!PromoCode.IsValidPromoCode())
            {
                IsValid = false;
                Message = "Please enter a valid promo code.";
                result = false;
            }

            return result;
        }

        private void InitializeAppliction()
        {
            if (!_startupService.IsFirstRunComplete())
            {
                try
                {
                    // Show Activity Indicator
                    IsPresentingPromoCodeUI = true;

                    // Fresh Installation
                    _startupService.FreshInstallationTasks(PromoCode);

                    //  Theme Initialization
                    Type theme = typeof(Themes.Default);
                    Application.Current.Resources.MergedWith = theme;
                    _themeService.SetTheme(theme.Name);


                }
                finally
                {
                    // Hide Activity Indicator
                    IsPresentingPromoCodeUI = false;
                }
            }

            // Add Revision Code to Database
            _startupService.AddRevisionCode();

            // Check For Registration
            if (!_startupService.CheckForRegistration())
            {
                Application.Current.MainPage = new InstallationPage();
                return;
            }

            GotoNextProcess();
        }

        private void GotoNextProcess()
        {
            // check for OEM reminder


            // check for setup file on the desktop and Twain

            // Load Theme

            // Goto Main
            if (!_startupService.IsFirstRunComplete())
                Application.Current.MainPage = new HOPage();
            else
                Root.NavigateAsync(Models.Menus.MenuType.milkDigitalID);
        }
        public async Task<bool> Authenticate()
        {
            bool success = false;
            try
            {
                success = _softwareService.IsValidPromoCode(PromoCode);
            }
            catch (System.Exception ex)
            {
                await Application
                      .Current
                      .MainPage
                      .DisplayAlert("Login error", "An unknown login error has occurred. " + ex.Message + ". Please try again.", "OK");
            }
            finally
            {
                // When the App.Authenticate() returns, the login UI is hidden, regardless of success (for example, if the user taps "Cancel" in iOS).
                // This means the SplashPage will be visible again, so we need to make the sign in button clickable again by hiding the activity indicator (via the IsPresentingLoginUI property).
                // IsPresentingPromoCodeUI = false;
            }

            return success;
        }
    }
}
