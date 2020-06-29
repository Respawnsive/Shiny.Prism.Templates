using System;
using System.Globalization;
using Xamarin.Forms;

namespace Template.Mobile.Converters
{
    public class WithoutExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(string))
                return null;

            string[] segments = value.ToString().Split('.');
            return segments[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
