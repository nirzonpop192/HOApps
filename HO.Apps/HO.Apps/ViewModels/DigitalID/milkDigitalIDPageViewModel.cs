using HO.Apps.Contracts;
using HO.Apps.Controls.Pages;
using HO.Apps.Models;
using HO.Apps.Pages.DigitalID;
using HO.Apps.Pages.Installation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HO.Apps.ViewModels.DigitalID
{
    public class milkDigitalIDPageViewModel : BaseViewModel
    {
        private readonly ImilkDigitalIDService _milkDigitalIDService;
        HOPage Root;
        ObservableCollection<milkDigitalID> _milkdigitalIDs;
        Command _loadmilkDigitalIDsRemoteCommand;
        Command _addmilkDigitalIDCommand;
        Command _buttonCommand;

        public milkDigitalIDPageViewModel(INavigation navigation = null, HOPage root = null) :
            base(navigation)
        {
            Root = root;
            _milkDigitalIDService = DependencyService.Get<ImilkDigitalIDService>();
            milkDigitalIDs = new ObservableCollection<milkDigitalID>(_milkDigitalIDService.GetDigitalIDs());

            // Show Splash
            ShowSplash();
        }

        private async void ShowSplash()
        {
            if (!App.IsSplashShown)
            {
                App.IsSplashShown = true;
                await PushModalAsync(new SplashPage());
            }
        }

        public ObservableCollection<milkDigitalID> milkDigitalIDs
        {
            get { return _milkdigitalIDs; }
            set { Set(ref _milkdigitalIDs, value); }
        }

        public Command LoadmilkDigitalIDsRemoteCommand
        {
            get
            {
                return _loadmilkDigitalIDsRemoteCommand ??
                    (_loadmilkDigitalIDsRemoteCommand =
                    new Command(ExecuteLoadmilkDigitalIDsRemoteCommand));
            }
        }

        public Command AddmilkDigitalIDCommand
        {
            get
            {
                return _addmilkDigitalIDCommand ??
                    (_addmilkDigitalIDCommand = new Command(ExecuteAddmilkDigitalIDCommand));
            }
        }

        public Command ButtonCommand
        {
            get
            {
                return _buttonCommand ??
                    (_buttonCommand = new Command(async () => await ExecuteButtonCommand()));
            }
        }

        private async Task ExecuteButtonCommand()
        {
            // await Root.NavigateAsync(Models.Menus.MenuType.Home);
        }

        private void ExecuteAddmilkDigitalIDCommand()
        {
            Application.Current.MainPage = new NavigationPage(new AddmilkDigitalIDPage(Root));
        }

        private void ExecuteLoadmilkDigitalIDsRemoteCommand(object obj)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadmilkDigitalIDsRemoteCommand.ChangeCanExecute();
            milkDigitalIDs = new ObservableCollection<milkDigitalID>(_milkDigitalIDService.GetDigitalIDs());
            IsBusy = false;
            LoadmilkDigitalIDsRemoteCommand.ChangeCanExecute();
        }
    }
}
