
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HO.Apps.Pages.Home
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            ItemsSource = TabDataModel.All;           
        }
    }

    public class TabDataModel
    {
        public string Name { set; get; }
        public string Content { get; set; }

        public static IList<TabDataModel> All { set; get; }

        static TabDataModel()
        {
            All = new ObservableCollection<TabDataModel> {
                new TabDataModel
                {
                    Name = "Tab 1",
                    Content = "Tab 1 Content"
                },
                new TabDataModel
                {
                    Name = "Tab 2",
                    Content = "Tab 2 Content"
                },
                new TabDataModel
                {
                    Name = "Tab 3",
                    Content = "Tab 3 Content"
                }
            };
        }
    }
}
