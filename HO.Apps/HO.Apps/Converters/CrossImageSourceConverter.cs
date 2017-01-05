using System;
using System.Globalization;
using Xamarin.Forms;

namespace HO.Apps.Converters
{
    public class CrossImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource source = Device.OnPlatform(
                   iOS: ImageSource.FromFile($"Images/{value}"),
                   Android: ImageSource.FromFile(value.ToString()),
                   WinPhone: ImageSource.FromFile($"Images/{value}"));

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
