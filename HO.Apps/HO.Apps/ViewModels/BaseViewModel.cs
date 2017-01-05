using HO.Apps.Mvvm;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HO.Apps.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        public INavigation Navigation { get; set; }

        public BaseViewModel(INavigation navigation = null)
        {
            Navigation = navigation;
        }

        public bool IsInitialized { get; set; }

        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopAsync();
        }

        bool canLoadMore;
        /// <summary>
        /// Gets or sets the "IsBusy" property
        /// </summary>
        /// <value>The isbusy property.</value>

        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { Set(ref canLoadMore, value); }
        }

        bool isBusy;
        /// <summary>
        /// Gets or sets the "IsBusy" property
        /// </summary>
        /// <value>The isbusy property.</value>        

        public bool IsBusy
        {
            get { return isBusy; }
            set { Set(ref isBusy, value); }
        }

        string title = string.Empty;
        /// <summary>
        /// Gets or sets the "Title" property
        /// </summary>
        /// <value>The title.</value>

        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        string subTitle = string.Empty;
        /// <summary>
        /// Gets or sets the "Subtitle" property
        /// </summary>

        public string Subtitle
        {
            get { return subTitle; }
            set { Set(ref subTitle, value); }
        }

        string icon = null;
        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>

        public string Icon
        {
            get { return icon; }
            set { Set(ref icon, value); }
        }

        private bool isValid = true;
        public bool IsValid
        {
            get { return isValid; }
            set { Set(ref isValid, value); }
        }

        string promoCode;
        public string PromoCode
        {
            get { return promoCode; }
            set { Set(ref promoCode, value); }
        }


        private string message;
        public string Message
        {
            get { return message; }
            set { Set(ref message, value); }
        }
    }
}
