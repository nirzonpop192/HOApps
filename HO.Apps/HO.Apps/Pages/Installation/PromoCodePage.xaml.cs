
using HO.Apps.Controls.Pages;
using HO.Apps.ViewModels.Installation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HO.Apps.Pages.Installation
{
    public partial class PromoCodePage : PromoCodePageXaml
    {
        public PromoCodePage(HOPage root = null)
        {
            InitializeComponent();
            BindingContext = new PromoCodePageViewModel(Navigation) {  };
            // VerifyButton.Clicked += VerifyButton_Clicked;
        }

        private async void VerifyButton_Clicked(object sender, System.EventArgs e)
        {
            ProgressActivity.IsVisible = true;
            ProgressActivity.IsRunning = true;

            if (App.IsConnected)
            {
                // trigger the activity indicator through the IsPresentingPromoCodeUI property on the ViewModel

                if (await ViewModel.Authenticate())
                {
                    //Thread.Sleep(5000);
                    await Navigation.PushAsync(new InstallationPage());
                }
            }
            else
            {

            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // pause for a moment before animations
            await Task.Delay(App.AnimationSpeed);

            // Sequentially animate the login buttons. ScaleTo() makes them "grow" from a singularity to the full button size.
            await VerifyButton.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
        }
    }

    public abstract class PromoCodePageXaml : ModelBoundContentPage<PromoCodePageViewModel> { }
}
