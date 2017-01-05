// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace HO.Apps.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }
        public static string GeneralSettings
        {
            get { return AppSettings.GetValueOrDefault(SettingConstant.GeneralSetting, SettingConstant.SettingsDefault); }
            set { AppSettings.AddOrUpdateValue(SettingConstant.GeneralSetting, value); }
        }

        public static bool IsSplashShown
        {
            get { return AppSettings.GetValueOrDefault<bool>(SettingConstant.SplashShown); }
            set { AppSettings.AddOrUpdateValue(SettingConstant.SplashShown, value); }
        }
        public static bool IsInitialized
        {
            get { return AppSettings.GetValueOrDefault<bool>(SettingConstant.ApplicationInitialize); }
            set { AppSettings.AddOrUpdateValue(SettingConstant.ApplicationInitialize, value); }
        }

        public static string PromoCode
        {
            get { return AppSettings.GetValueOrDefault<string>(SettingConstant.PromoCodeKey); }
            set { AppSettings.AddOrUpdateValue(SettingConstant.PromoCodeKey, value); }
        }

        public static string InitialLanguage
        {
            get { return AppSettings.GetValueOrDefault<string>(SettingConstant.InitialLanguageKey); }
            set { AppSettings.AddOrUpdateValue(SettingConstant.InitialLanguageKey, value); }
        }

        public static string ImageryConceptSite
        {
            get { return AppSettings.GetValueOrDefault<string>(SettingConstant.ImageryConceptSiteKey); }
            set { AppSettings.AddOrUpdateValue(SettingConstant.ImageryConceptSiteKey, value); }
        }

        public static string RevisionCode
        {
            get { return AppSettings.GetValueOrDefault<string>(SettingConstant.RevisionCodeKey); }
            set { AppSettings.AddOrUpdateValue(SettingConstant.RevisionCodeKey, value); }
        }
    }
}