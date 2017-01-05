using HO.Apps.ViewModels.About;

namespace HO.Apps.Pages.About
{
    public partial class AboutPage : AboutPageXaml
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }

    public class AboutPageXaml : ModelBoundContentPage<AboutPageViewModel> { }
}
