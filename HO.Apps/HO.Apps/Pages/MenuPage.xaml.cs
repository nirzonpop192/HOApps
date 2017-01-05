using HO.Apps.Controls.Pages;
using HO.Apps.Models;
using HO.Apps.Models.Menus;
using HO.Apps.ViewModels;
using Xamarin.Forms;

namespace HO.Apps.Pages
{
    public partial class MenuPage : ContentPage
    {
        HOPage Root;
        MenuPageViewModel vm;
        public MenuPage(HOPage root)
        {
            Root = root;
            InitializeComponent();
            if (!App.IsWindows10)
            {
                //BackgroundColor = Color.FromHex("#03A9F4");
                //ListViewMenu.BackgroundColor = Color.FromHex("#36B0BB");
            }

            vm = new MenuPageViewModel(Root, Navigation)
            {
                Title = "m.i.l.k. Digital ID",
                Subtitle = "m.i.l.k. Digital ID",
                Icon = "slideout.png"
            };

            BindingContext = vm;
        }

        async void MenuItemTapped(object sender, ItemTappedEventArgs e)
        {
            HomeMenuItem selectedItem = e.Item as HomeMenuItem;
            if (selectedItem == null)
                return;
            await Root.NavigateAsync(selectedItem.MenuType);
        }
        private void SponsorItemTapped(object sender, ItemTappedEventArgs e)
        {
            Sponsor selectedItem = e.Item as Sponsor;
            if (selectedItem == null)
                return;

            Device.OpenUri(new System.Uri(selectedItem.SponsorUrl));
        }
    }






    //HOPage Root;
    //List<HomeMenuItem> _menuItems;
    //private readonly IMenuService _menuService;
    //public MenuPage(HOPage root)
    //{
    //    Root = root;
    //    _menuService = DependencyService.Get<IMenuService>();
    //    InitializeComponent();
    //    if (!App.IsWindows10)
    //    {
    //        //BackgroundColor = Color.FromHex("#03A9F4");
    //        //ListViewMenu.BackgroundColor = Color.FromHex("#36B0BB");
    //    }


    //    BindingContext = new BaseViewModel(Navigation)
    //    {
    //        Title = "m.i.l.k. Digital ID",
    //        Subtitle = "m.i.l.k. Digital ID",
    //        Icon = "slideout.png"
    //    };


    //    ListViewMenu.ItemsSource = _menuItems = _menuService.GetMenus();

    //    ListViewMenu.SelectedItem = _menuItems[0];
    //    ListViewMenu.ItemSelected += async (sender, e) =>
    //    {
    //        if (ListViewMenu.SelectedItem == null)
    //            return;

    //        await Root.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
    //    };
    //}

    public class SponsorModel
    {
        public string Name { get; set; }
        public string ICON { get; set; }
        public string Url { get; set; }
    }
}

