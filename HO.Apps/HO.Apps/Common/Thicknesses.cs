using Xamarin.Forms;

namespace HO.Apps.Common
{
    public static class Thicknesses
    {
        public static Thickness Empty
        {
            get { return new Thickness(0, 0, 0, 0); }
        }

        public static Thickness IosStatusBar
        {
            get { return new Thickness(0, 20, 0, 0); }
        }
    }
}
