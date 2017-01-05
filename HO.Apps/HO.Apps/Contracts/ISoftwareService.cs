using HO.Apps.Messaging;
using HO.Apps.Models;

namespace HO.Apps.Contracts
{
    public interface ISoftwareService
    {
        bool IsValidPromoCode(string promoCode);
        SplashDefinition AgentSplashDefData(string registrationId, string promoCode);
        string GetAgentSplash(string registrationId, string promoCode);
        string GetImageId(string registrationId, string promoCode);
        string GetMessageText(string registrationId, string promoCode);
        SponsorZip GetSponsorZipFiles(string registrationId, string promoCode);
        string HO_3_0_0();
        string HO_4_0_0();
        ImageResponse IsRegistrationKeyValid(string registrationID, string promoCode);
        RegistrationResponse MemberRegistration(RegistrationRequest request);
        string[] GetSponsorIds(string registrationId, string promoCode);
    }
}
