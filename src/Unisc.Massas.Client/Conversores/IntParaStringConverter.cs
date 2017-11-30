using System;
using System.Globalization;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class IntParaStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inteiro = value as int?;

            if (inteiro.HasValue)
            {
                return inteiro == 0 ? "" : inteiro.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var palavra = value as string;

            if (Int32.TryParse(palavra.Replace("-", "").Replace("_", ""), out int result))
            {
                return result;
            }

            return value;
        }
    }
}
