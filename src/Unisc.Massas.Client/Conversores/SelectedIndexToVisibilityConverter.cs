using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class SelectedIndexToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = value as int?;

            return index.HasValue && index.Value == 1 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
