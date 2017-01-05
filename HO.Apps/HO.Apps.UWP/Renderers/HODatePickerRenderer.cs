using HO.Apps.Controls;
using HO.Apps.UWP.Renderers;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(HODatePicker), typeof(HODatePickerRenderer))]
namespace HO.Apps.UWP.Renderers
{
    public class HODatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderBrush = new SolidColorBrush(Colors.Transparent);
                Control.Background = new SolidColorBrush(Colors.Transparent);
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0, 0, 0, 1);
            }
        }
    }
}
