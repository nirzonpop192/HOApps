using Xamarin.Forms;

namespace HO.Apps.ViewModels.Home
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigation navigation = null)
            : base(navigation)
        {
            IsBusy = true;
        }
    }
}
