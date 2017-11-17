using System;
using System.Globalization;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class CnpjCpfToSelectedIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cnpjCpf = value as string;

            if (String.IsNullOrEmpty(cnpjCpf))
                return -1;
            if (cnpjCpf.Length == 11)
                return 0;

            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
