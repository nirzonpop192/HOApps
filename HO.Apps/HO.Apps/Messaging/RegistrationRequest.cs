namespace HO.Apps.Messaging
{
    public class RegistrationRequest
    {
        public string DevUserKey { get; set; }
        public string DevLicenseKey { get; set; }
        public string PromoCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public string ZipCode { get; set; }
        public int PreferredLanguage { get; set; }
        public bool SubscribeToEarsNotification { get; set; }
        public bool SubscribeToMilkNotification { get; set; }
    }
}
