using HO.Apps.Models.Menus;
using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface IMenuService
    {
        List<HomeMenuItem> GetMenus();
    }
}
