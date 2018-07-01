using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinFormsDemo.Converters
{
    class BoolToControlVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var visbility = value as bool? ?? false;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (bool)value ? 1 : 0;
        }
    }
}
