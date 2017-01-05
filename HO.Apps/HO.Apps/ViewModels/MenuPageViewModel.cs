using HO.Apps.Contracts;
using HO.Apps.Controls.Pages;
using HO.Apps.Models;
using HO.Apps.Models.Menus;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HO.Apps.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        private readonly IMenuService _menuService;
        private readonly ISponsorService _sponsorService;
        HOPage _root;
        List<HomeMenuItem> _menuItems;
        ObservableCollection<Sponsor> _sponsors;


        public MenuPageViewModel(HOPage root, INavigation navigation = null)
            : base(navigation)
        {
            _sponsorService = DependencyService.Get<ISponsorService>();
            _menuService = DependencyService.Get<IMenuService>();
            _root = root;
            MenuItems = _menuService.GetMenus();
            Sponsors = new ObservableCollection<Sponsor>(_sponsorService.GetDownloadedSponsors());
        }

        public string ApplicationTitle { get; set; } = "m.i.l.k. Digital ID";

        public HOPage Root
        {
            get { return _root; }
            set { Set(ref _root, value); }
        }

        public List<HomeMenuItem> MenuItems
        {
            get { return _menuItems; }
            set { Set(ref _menuItems, value); }
        }

        public ObservableCollection<Sponsor> Sponsors
        {
            get { return _sponsors; }
            set { Set(ref _sponsors, value); }
        }
    }
}
