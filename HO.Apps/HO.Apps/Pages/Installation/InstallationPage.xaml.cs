using HO.Apps.ViewModels.Installation;
using Xamarin.Forms;

namespace HO.Apps.Pages.Installation
{
    public partial class InstallationPage : ContentPage
    {
        InstallationPageViewModel vm;
        public InstallationPage()
        {
            InitializeComponent();
            vm = new InstallationPageViewModel(Navigation) { Title = "First Time Installation" };
            BindingContext = vm;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (vm != null)
            {
                // Load Secret Questions
                SecretQuestionsPicker.Items.Clear();
                foreach (var item in vm.SecretQuestions)
                {
                    SecretQuestionsPicker.Items.Add(item);
                }

                // Load Language Preferences
                LanguagePreferencePicker.Items.Clear();
                foreach (var item in vm.LanguagePreferences)
                {
                    LanguagePreferencePicker.Items.Add(item);
                }
            }
        }

        private void SecretQuestionsPicker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int selectedIndex = ((Picker)sender).SelectedIndex;
            string selectedItem = vm.SecretQuestions[selectedIndex];
            vm.SelectedSecretQuestion = selectedItem;
        }

        private void LanguagePreferencePicker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int selectedIndex = ((Picker)sender).SelectedIndex;
            string selectedItem = vm.LanguagePreferences[selectedIndex];
            vm.SelectedLanguagePreference = selectedItem;
        }

        private void milkSwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                vm.SubscribeTomilkNotification = true;
            }
            else
            {
                vm.SubscribeTomilkNotification = false;
            }
        }

        private void earsSwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                vm.SubscribeToEARSNotification = true;
            }
            else
            {
                vm.SubscribeToEARSNotification = false;
            }
        }
    }
}
