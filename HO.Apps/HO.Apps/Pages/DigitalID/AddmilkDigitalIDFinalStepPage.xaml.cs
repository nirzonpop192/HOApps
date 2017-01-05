using HO.Apps.Models;
using HO.Apps.ViewModels.DigitalID;

using Xamarin.Forms;

namespace HO.Apps.Pages.DigitalID
{
    public partial class AddmilkDigitalIDFinalStepPage : ContentPage
    {
        public AddmilkDigitalIDFinalStepPage(FirstStepModel firstStep = null)
        {
            InitializeComponent();
            BindingContext = new AddmilkDigitalIDFinalStepPageViewModel(Navigation, firstStep)
            {
                Title = "Add milk Digital ID Final Step"
            };
        }
    }
}
