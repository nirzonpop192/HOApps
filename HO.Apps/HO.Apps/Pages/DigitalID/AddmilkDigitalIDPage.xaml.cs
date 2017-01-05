using HO.Apps.Controls.Pages;
using HO.Apps.ViewModels.DigitalID;
using System;

using Xamarin.Forms;

namespace HO.Apps.Pages.DigitalID
{
    public partial class AddmilkDigitalIDPage : ContentPage
    {
        AddmilkDigitalIDPageViewModel vm;
        HOPage Root;
        public AddmilkDigitalIDPage(HOPage root = null)
        {
            InitializeComponent();
            Root = root;
            vm = new AddmilkDigitalIDPageViewModel(Navigation, root) { Title = "Add milk Digital ID" };
            BindingContext = vm;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (vm != null)
            {
                GenderPicker.Items.Clear();
                foreach (var item in vm.Gender)
                {
                    GenderPicker.Items.Add(item);
                }
            }
        }

        private void GenderPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((Picker)sender).SelectedIndex;
            string selectedItem = vm.Gender[selectedIndex];
            vm.FirstStep.Gender = selectedItem;
        }
    }
}
