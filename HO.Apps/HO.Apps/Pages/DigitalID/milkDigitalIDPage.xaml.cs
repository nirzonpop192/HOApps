using HO.Apps.Controls.Pages;
using HO.Apps.Models;
using HO.Apps.Pages.Installation;
using HO.Apps.ViewModels.DigitalID;
using Xamarin.Forms;

namespace HO.Apps.Pages.DigitalID
{
    public partial class milkDigitalIDPage : milkDigitalIDPageXaml
    {
        public milkDigitalIDPage(HOPage root = null)
        {
            InitializeComponent();
            BindingContext = new milkDigitalIDPageViewModel(Navigation, root);
        }

        private void ShowSplash()
        {
            Navigation.PushModalAsync(new SplashPage());
        }

        async void DigitalIDItemTapped(object sender, ItemTappedEventArgs e)
        {
            await DisplayAlert("Selectd Item:", (e.Item as milkDigitalID).NickName, "Ok");
        }
    }

    public abstract class milkDigitalIDPageXaml : ModelBoundContentPage<milkDigitalIDPageViewModel> { }
}
