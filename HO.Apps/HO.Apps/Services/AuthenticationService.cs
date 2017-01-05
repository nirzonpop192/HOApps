using HO.Apps.Contracts;
using HO.Apps.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthenticationService))]
namespace HO.Apps.Services
{
    public class AuthenticationService : IAuthenticationService
    {       
        private readonly ISoftwareService _softwareService;
        public AuthenticationService()
        {           
            _softwareService = DependencyService.Get<ISoftwareService>();
        }
        public bool IsAuthenticated
        {
            get
            {
                //if (!string.IsNullOrWhiteSpace(Settings.GeneralSettings))
                //    return true;

                //return false;

                if (_AuthenticationBypassed)
                    return true;

                return false;
            }
        }

        public async Task<bool> AuthenticateAsync(string promoCode)
        {
            var result = _softwareService.IsValidPromoCode(promoCode);
            //if (result)
            //    Settings.GeneralSettings = promoCode;
            if (result)
                _AuthenticationBypassed = true;


            return result;
        }

        public Task<bool> AuthenticateAsync()
        {
            throw new NotImplementedException();
        }

        bool _AuthenticationBypassed;
        public void BypassAuthentication()
        {
            _AuthenticationBypassed = true;
        }

        public Task<string> GetTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
