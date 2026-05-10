using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FilterPlus.Converters
{
    public class EnumToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            return value.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null || !(bool)value) return System.Windows.Data.Binding.DoNothing;
            return Enum.Parse(targetType, parameter.ToString());
        }
    }
}
