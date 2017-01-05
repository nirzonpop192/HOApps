using HO.Apps.Helpers;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace HO.Apps.Converters
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is byte[])
                {
                    return (value as byte[]).FromBytes();
                }
                if (value is string && !value.ToString().IsEmpty())
                {
                    return value.ToString().FromBase64String();
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
