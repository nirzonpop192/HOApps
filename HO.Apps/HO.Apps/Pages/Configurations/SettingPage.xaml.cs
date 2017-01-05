using HO.Apps.ViewModels.Configurations;
using Xamarin.Forms;

namespace HO.Apps.Pages.Configurations
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            BindingContext = new SettingPageViewModel(Navigation);
            ThemePanel.IsVisible = false;
        }

        private void ThemeChanged(object sender, ToggledEventArgs e)
        {
            //BindingContext = new SettingPageViewModel(Navigation);
            //if (e.Value == true)
            //{
            //    (BindingContext as SettingPageViewModel).IsThemeEnabled = true;
            //    // ThemePanel.IsVisible = true;
            //    TestButton.IsVisible = true;
            //}
            //else
            //{
            //    (BindingContext as SettingPageViewModel).IsThemeEnabled = false;
            //    // ThemePanel.IsVisible = false;
            //    TestButton.IsVisible = false;
            //}
        }

        private void TestButton_Clicked(object sender, System.EventArgs e)
        {
            ThemePanel.IsVisible = true;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            ThemePanel.IsVisible = !ThemePanel.IsVisible;
        }

        private void ThemeSwitchTapped(object sender, System.EventArgs e)
        {
            ThemeSwitch.On = !ThemeSwitch.On;
            if (ThemeSwitch.On)
                ThemePanel.IsVisible = true;
            else
                ThemePanel.IsVisible = false;
        }

        private void ResetSwitchTapped(object sender, System.EventArgs e)
        {
            ResetSwitch.On = !ResetSwitch.On;
            if (ResetSwitch.On)
            {
                // Reset Application
            }
        }
    }
}
