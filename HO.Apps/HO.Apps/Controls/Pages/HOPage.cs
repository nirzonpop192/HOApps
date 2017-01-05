using HO.Apps.Localization;
using HO.Apps.Models.Menus;
using HO.Apps.Pages;
using HO.Apps.Pages.About;
using HO.Apps.Pages.Configurations;
using HO.Apps.Pages.DigitalID;
using HO.Apps.Pages.Installation;
using HO.Apps.ViewModels;
using HO.Apps.ViewModels.About;
using HO.Apps.ViewModels.Configurations;
using HO.Apps.ViewModels.DigitalID;
using HO.Apps.ViewModels.Installation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HO.Apps.Controls.Pages
{
    public class HOPage : MasterDetailPage
    {
        public static bool IsUWPDesktop { get; set; }
        Dictionary<MenuType, NavigationPage> Pages { get; set; }

        public HOPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel(Navigation)
            {
                Title = "Home Orgainzer",
                Icon = "slideout.png"
            };

            // setup home page
            NavigateAsync(MenuType.milkDigitalID);
            InvalidateMeasure();
        }

        void SetDetailIfNull(Page page)
        {
            if (Detail == null && page != null)
                Detail = page;
        }

        public async Task NavigateAsync(MenuType id)
        {
            if (Detail != null)
            {

                if (IsUWPDesktop || Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;

                if (Device.OS == TargetPlatform.Android)
                    await Task.Delay(300);
            }

            Page newPage;

            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.PromoCode:
                        var page = new HONavigationPage(new PromoCodePage(this)
                        {
                            BindingContext = new PromoCodePageViewModel(Navigation, this),
                            Title = TextResources.Page_PromoCode,
                            Icon = new FileImageSource { File = "icon.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.milkDigitalID:
                        page = new HONavigationPage(new milkDigitalIDPage(this)
                        {
                            BindingContext = new milkDigitalIDPageViewModel(Navigation, this),
                            Title = TextResources.Page_milkDigitalID,
                            Icon = new FileImageSource { File = "icon.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.AddmilkDigitalID:
                        page = new HONavigationPage(new AddmilkDigitalIDPage()
                        {
                            BindingContext = new AddmilkDigitalIDPageViewModel(Navigation),
                            Title = TextResources.Page_milkDigitalID,
                            Icon = new FileImageSource { File = "icon.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.Setting:
                        page = new HONavigationPage(new SettingPage
                        {
                            BindingContext = new SettingPageViewModel(Navigation),
                            Title = TextResources.Page_SettingTitle,
                            Icon = new FileImageSource { File = "icon.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.About:
                        page = new HONavigationPage(new AboutPage
                        {
                            BindingContext = new AboutPageViewModel(Navigation),
                            Title = TextResources.Page_AboutTitle,
                            Icon = new FileImageSource { File = "about.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            // pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}
