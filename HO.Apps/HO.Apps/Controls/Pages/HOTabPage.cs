using HO.Apps.Localization;
using HO.Apps.Pages.About;
using HO.Apps.Pages.Configurations;
using HO.Apps.Pages.DigitalID;
using HO.Apps.Pages.Home;
using HO.Apps.ViewModels.About;
using HO.Apps.ViewModels.Configurations;
using HO.Apps.ViewModels.DigitalID;
using HO.Apps.ViewModels.Home;
using Xamarin.Forms;

namespace HO.Apps.Controls.Pages
{
    public class HOTabPage : TabbedPage
    {
        public HOTabPage()
        {
            Children.Add(new HONavigationPage(new HomePage
            {
                BindingContext = new HomePageViewModel(Navigation),
                Title = TextResources.Page_HomeTitle,
                Icon = new FileImageSource { File = "home.png" }
            })
            {
                Title = TextResources.Page_HomeTitle,
                Icon = new FileImageSource { File = "home.png" }
            });
            Children.Add(new HONavigationPage(new milkDigitalIDPage
            {
                BindingContext = new milkDigitalIDPageViewModel(Navigation),
                Title = TextResources.Page_milkDigitalID,
                Icon = new FileImageSource { File = "girl.png" }
            })
            {
                Title = TextResources.Page_milkDigitalID,
                Icon = new FileImageSource { File = "girl.png" }
            });
            Children.Add(new HONavigationPage(new SettingPage
            {
                BindingContext = new SettingPageViewModel(Navigation),
                Title = TextResources.Page_SettingTitle,
                Icon = new FileImageSource { File = "setting.png" }
            })
            {
                Title = TextResources.Page_SettingTitle,
                Icon = new FileImageSource { File = "setting.png" },
            });
            Children.Add(new HONavigationPage(new AboutPage
            {
                BindingContext = new AboutPageViewModel(Navigation),
                Title = TextResources.Page_AboutTitle,
                Icon = new FileImageSource { File = "info.png" }
            })
            {
                Title = TextResources.Page_AboutTitle,
                Icon = new FileImageSource { File = "info.png" }
            });
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage.Title;
        }
    }
}
