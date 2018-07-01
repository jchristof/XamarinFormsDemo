using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsDemo.Converters
{
    class DoubleToTimeString : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var milliseconds = value as double? ?? 0.0;
            return TimeSpan.FromSeconds(milliseconds).ToString(@"m\:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return 0;
        }
    }
}
