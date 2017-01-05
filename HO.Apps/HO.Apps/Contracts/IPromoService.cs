using HO.Apps.Messaging;
using HO.Apps.Models;

namespace HO.Apps.Contracts
{
    public interface IPromoService
    {
        string GetImageId(string registrationId, string promoCode);
        string GetSponsorId(string registrationId, string promoCode);
        SponsorZip GetSponsorData();
        void CheckSponsor();
        string GetSplashImage();
        SplashDefinition GetSplashDefData();
        void CommonSplashData(SplashDefinition splashDefinition);
        bool IsPromoCodeValid(string promoCode);
        bool RegisterMember(RegistrationRequest requst);
        bool IsRegistrationIdValid(string registrationId);
        void UpdatePromo();
    }
}
