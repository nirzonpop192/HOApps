using System.Threading.Tasks;

namespace HO.Apps.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string promoCode);
        Task<bool> AuthenticateAsync();

        Task<bool> LogoutAsync();

        Task<string> GetTokenAsync();

        bool IsAuthenticated { get; }

        /// <summary>
        /// Used only for demo, to quickly bypass actual authentication
        /// </summary>
        /// <returns>Task</returns>
        void BypassAuthentication();
    }
}

