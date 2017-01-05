namespace HO.Apps.Helpers
{
    public static class ServiceUrl
    {
        public const string SoftwareTestUrl = "http://apitest.home-organizer.com/api/Software/";
        public const string IsPromoCodeValidUrl = "IsPromoCodeValid";
        public const string AgentSplashDefDataUrl = "AgentSplashDefData";
        public const string AgentSplashUrl = "GetAgentSplash";
        public const string ImageIdUrl = "GetImageId";
        public const string MessageTextUrl = "GetMessageText";
        public const string SponsorZipFilesUrl = "GetSponsorZipFiles";
        public const string GetSponsorIdsUrl = "GetSponsorIds";
        public const string HO3VersionUrl = "HO_3_0_0";
        public const string HO4VersionUrl = "HO_4_0_0";
        public const string RegistrationdKeyUrl = "IsRegistrationKeyValid";
        public const string MemberRegistrationUrl = "MemberRegistration";
        public static string GetUrl(string environment = "")
        {
            return SoftwareTestUrl;
        }
    }
    public static class MessagingServiceConstants
    {
        public const string Authenticated = "AUTHENTICATED";
    }

    public static class SettingConstant
    {
        public const string SettingsDefault = "";
        public const string GeneralSetting = "GeneralSettingKey";
        public const string SplashShown = "SplashShownKey";
        public const string ApplicationInitialize = "ApplicationInitializeKey";
        public const string PromoCodeKey = "PromoCodeKey";
        public const string RegistrationKey = "RegistrationKey";
        public const string InitialLanguageKey = "InitialLanguageKey";
        public const string InitialLanguage = "en-US";
        public const string RevisionCodeKey = "RevisionCodeKey";
        public const string RevisionCode = "20130315";
        public const string SplashImageIDKey = "SplashImageIDKey";
        public const string SponsorListKey = "SponsorListKey";
        public const string SponsorIdKey = "SponsorIdKey";
        public const string FirstRunCompleteKey = "FirstRunCompleteKey";
        public const string MachineKey = "MachineKey";
        public const string CultureKey = "CultureKey";
        public const string DateInstalledKey = "DateInstalledKey";
        public const string AgentXMLDataKey = "AgentXMLDataKey";
        public const string MessageFromServerKey = "MessageFromServerKey";
        public const string SplashPictureKey = "SplashPictureKey";

        public const string ImageryConceptSiteKey = "SecureSite";
        public const string ImageryConceptSite = "http://secure.imageryconcepts.biz/";

        // Date Time Format
        public const string DefaultDateTimeFormat = "dd MMM yyyy hh:mm:ss";

        // Separator
        public const string TabSeparator = "\t";
        public const string LineBreak = "\r\n";

        // Image Url
        public const string ImageryConceptImageUrl = ImageryConceptSite + "icws/";
        public const string AgentImageUrl = ImageryConceptImageUrl + "agentimage/";
        public const string SponosrImageUrl = ImageryConceptImageUrl + "sponsorimage/";

        // Digital ID
        public const string milkDigitalID = SponosrImageUrl + "/milk_sponsorbutton.bmp, milk Digital Id, http://www.milkdigitalid.com";
        public const string SilverDigitalID = SponosrImageUrl + "/silver_sponsorbutton.bmp, Silver Digital Id, http://www.silverdigitalid.com";
        public const string EarsWebSite = SponosrImageUrl + "/ears_sponsorbutton.bmp, EARS web site, http://www.petdigitalid.com";


    }

    public static class ApplicationSettingsConstant
    {
        public const string RootDirectory = @"Imagery Concepts, LLC/Digital ID";
        public const string LogDirectory = "Logs";
        public const string DatabaseDirectory = "Database";
        public const string DocumentsDirectory = "Documents";
        public const string ImportDirectory = "Import";
        public const string LibraryDirectory = "Library";
        public const string OpenDocuemntsDirectory = "OpenDocuments";
        public const string TempDirectory = "Temp";
        public const string PictureDirectory = @"Imagery Concepts, LLC\Digital ID\Picture";
        public const string VideoDirectory = @"Imagery Concepts, LLC\Digital ID\Videos";
        public const string DatabaseName = "milkDb.db3";
        public const string SponsorFileName = "Sponsors.txt";
        public const string InstallerFileName = "Installer.txt";
        public const string DataLocationiFile = "DataLocation.txt";
        public const string ThemePrefix = "Theme:";
    }
}
