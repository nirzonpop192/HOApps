using HO.Apps.Contracts;
using HO.Apps.Helpers;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HO.Apps.ViewModels.Installation
{
    public class SplashPageViewModel : BaseViewModel
    {
        private readonly IGlobalOptionService _globalOptionService;
        private readonly ISoftwareService _softwareService;
        private readonly ILogService _logService;
        private readonly IPromoService _promoService;
        ICommand _tapCommand;
        public SplashPageViewModel(INavigation navigation)
            : base(navigation)
        {
            _globalOptionService = DependencyService.Get<IGlobalOptionService>();
            _softwareService = DependencyService.Get<ISoftwareService>();
            _logService = DependencyService.Get<ILogService>();
            _promoService = DependencyService.Get<IPromoService>();

            SetImage();
            SetSize();

            // Setup the sponsor info
            try
            {
                SetSponsor();
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }

        }

        private void SetSponsor()
        {
            _promoService.CheckSponsor();
        }

        private void SetSize()
        {
            // throw new NotImplementedException();
        }

        private void SetImage()
        {
            string image = _promoService.GetSplashImage();
            if (image.IsEmpty())
                Name = "Splash.jpg".CrossPlatformImageSource();
            else
                Name = image;
        }

        public string Name { get; set; }
        public ICommand TapCommand
        {
            get
            {
                return _tapCommand ??
                    (_tapCommand = new Command(ExecuteTapCommand));
            }
        }

        private async void ExecuteTapCommand()
        {
            await PopModalAsync();
        }
    }
}
