using HO.Apps.Controls.Pages;
using Windows.System.Profile;

namespace HO.Apps.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Apps.App.IsWindows10 = true;
            HOPage.IsUWPDesktop = AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Desktop";
            LoadApplication(new Apps.App());
        }
    }
}
