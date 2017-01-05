using Newtonsoft.Json;

namespace HO.Apps.Messaging
{
    public class SplashDefinition
    {
        public bool ValidPromoCode { get; set; }
        public string SplashImage { get; set; }
        public string Picture { get; set; }
        public AgentXMLData AgentXMLData { get; set; }
        public string ImageId { get; set; }
        public string MessageText { get; set; }
        public string HoVersion { get; set; }
    }

    public class UserId
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }
    public class DateJoined
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }

    public class DateModified
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }

    public class SecondaryEmail
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }

    public class AgreementDate
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }

    public class EmailAddress
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }

    public class OldPromoCode
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }

    public class FirstPromoCode
    {
        [JsonProperty("#cdata-section")]
        public string CDataSection { get; set; }
    }

    public class Table
    {
        public string GroupName { get; set; }
        public string ICAgentId { get; set; }
        public UserId UserId { get; set; }
        public string UserName { get; set; }
        public string PromoId { get; set; }
        public string GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string CompanyName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string StatusId { get; set; }
        public DateJoined DateJoined { get; set; }
        public DateModified DateModified { get; set; }
        public SecondaryEmail SecondaryEmail { get; set; }
        public string AffAgentID { get; set; }
        public AgreementDate AgreementDate { get; set; }
        public string URL { get; set; }
        public string LanguagePreference { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public OldPromoCode OldPromoCode { get; set; }
        public FirstPromoCode FirstPromoCode { get; set; }
        public string SPID { get; set; }
        public string AffAgentType { get; set; }
    }

    public class PROMOINFO
    {
        public Table Table { get; set; }
    }

    public class AgentXMLData
    {
        public PROMOINFO PROMOINFO { get; set; }
    }
}

