using HO.Apps.Pages.Installation;
using System;

using Xamarin.Forms;

namespace HO.Apps.Views.DigitalID
{
    public partial class milkDigitalIDListView : NonPersistentSelectedItemListView
    {
        private bool IsEvenRow;
        public milkDigitalIDListView()
        {
            InitializeComponent();
        }

        private void ViewCell_Appearing(object sender, EventArgs e)
        {
            if (IsEvenRow)
            {
                var viewCell = (ViewCell)sender;
                if (viewCell.View != null)
                {
                    viewCell.View.BackgroundColor = Color.FromHex("03a9f4");
                }
            }

            IsEvenRow = !IsEvenRow;
        }
    }
}
