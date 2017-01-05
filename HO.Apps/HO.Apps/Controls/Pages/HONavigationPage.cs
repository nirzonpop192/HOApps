using Xamarin.Forms;

namespace HO.Apps.Controls.Pages
{
    public class HONavigationPage : NavigationPage
    {
        public HONavigationPage(Page root)
            : base(root)
        {
            Init();
        }

        public HONavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Color.Accent;
            // BarBackgroundColor = Color.FromHex("#CC1D1D");
            BarTextColor = Color.White;
        }
    }
}