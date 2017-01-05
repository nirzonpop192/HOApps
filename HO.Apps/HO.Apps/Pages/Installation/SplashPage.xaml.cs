using HO.Apps.ViewModels.Installation;

using Xamarin.Forms;

namespace HO.Apps.Pages.Installation
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            BindingContext = new SplashPageViewModel(Navigation);

            //Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
            //{
            //    ProgressInitilize.Progress += 0.01;
            //    if (ProgressInitilize.Progress > .5)
            //    {
            //        ProgressInitilize.Progress = 0;
            //        return false;
            //    }
            //    return true;
            //});
        }
    }
}
