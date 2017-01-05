using Xamarin.Forms;

namespace HO.Apps.ViewModels.Configurations
{
    public class SettingPageViewModel : BaseViewModel
    {
        public SettingPageViewModel(INavigation navigation = null)
            : base(navigation)
        {

        }

        private bool _isThemeEnabled;
        public bool IsThemeEnabled
        {
            get { return _isThemeEnabled; }
            set { Set(ref _isThemeEnabled, value); }
        }
        Command _changeTheme;
        public Command ChangeTheme
        {
            get
            {
                return _changeTheme ??
                  (_changeTheme = new Command(ExecuteChangeTheme));
            }
        }

        private void ExecuteChangeTheme(object theme)
        {
            Application.Current.Resources.MergedWith = null;
            switch (theme.ToString())
            {
                case "White":
                    Application.Current.Resources.MergedWith = typeof(Themes.Default);
                    break;
                case "Dark":
                    Application.Current.Resources.MergedWith = typeof(Themes.Dark);
                    break;
                default:
                    break;
            }
        }
    }
}
