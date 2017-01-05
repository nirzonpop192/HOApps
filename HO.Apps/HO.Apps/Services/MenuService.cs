using HO.Apps.Contracts;
using HO.Apps.Localization;
using HO.Apps.Models.Menus;
using HO.Apps.Services;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Dependency(typeof(MenuService))]
namespace HO.Apps.Services
{
    public class MenuService : IMenuService
    {
        public List<HomeMenuItem> GetMenus()
        {
            return new List<HomeMenuItem>()
            {
                new HomeMenuItem { Title = TextResources.Page_PromoCode, MenuType = MenuType.PromoCode, Icon = "ok.png" },
                new HomeMenuItem { Title = TextResources.Page_milkDigitalID, MenuType = MenuType.milkDigitalID, Icon = "Agent_32.png" },
                new HomeMenuItem { Title = TextResources.Page_AboutTitle, MenuType = MenuType.About, Icon = "info.png" },
                new HomeMenuItem { Title = TextResources.Page_SettingTitle, MenuType = MenuType.Setting, Icon = "setting.png" },
            };
        }
    }
}
