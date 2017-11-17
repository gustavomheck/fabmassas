using System;
using System.Globalization;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class SelectedIndexToIsEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = value as int?;

            return index.HasValue && index.Value > -1 ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
