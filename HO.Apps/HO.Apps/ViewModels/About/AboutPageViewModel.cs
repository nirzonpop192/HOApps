using Xamarin.Forms;

namespace HO.Apps.ViewModels.About
{
    public class AboutPageViewModel : BaseViewModel
    {
        public AboutPageViewModel(INavigation navigation = null)
            : base(navigation)
        {

        }
        public string Description { get; set; }
        public string Uri { get; set; } = "Hello From About Page";

        public bool UriIsPresent
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Uri);
            }
        }
    }
}
