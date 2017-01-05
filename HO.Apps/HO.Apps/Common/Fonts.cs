using Xamarin.Forms;

namespace HO.Apps.Common
{
    public static class Fonts
    {
        public static Font SystemFontAt150PercentOfLarge = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.5);
        public static Font SystemFontAt120PercentOfLarge = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.2);

        //public static Font SystemFontAt60PercentOfDefault = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Default, typeof(ChartAxisTitle)) * 0.6);
        //public static Font SystemFontAt170PercentOfDefault = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Default, typeof(ChartAxisTitle)) * 1.7);
    }
}
