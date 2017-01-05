namespace HO.Apps.Contracts
{
    public interface IStartupService
    {
        bool IsDigitalIDDirectoryExists();
        string GetAlternativeDataPath();
        bool IsFirstRunComplete();
        bool CheckForRegistration();
        void FreshInstallationTasks(string promoCode);
        void AddRevisionCode();
        void InilizeApplication();
        void InitializeDefaultSettings();
        void ResetApplication();

    }
}
