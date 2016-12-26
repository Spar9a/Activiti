using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace Activity
{
    public class JoinStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var separator = parameter as string ?? " ";
            return string.Join(separator, values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var separator = parameter as string ?? " ";
            return (value as string)?.Split(new[] { separator }, StringSplitOptions.None).Cast<object>().ToArray();
        }
    }
}
