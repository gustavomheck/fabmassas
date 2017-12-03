using System;
using System.Globalization;
using System.Windows.Data;
using Unisc.Massas.Core.Texto;

namespace Unisc.Massas.Client.Conversores
{
    public class CnpjCpfFormatter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var cnpj = values[0] as string;
            var cpf = values[1] as string;

            return Formatar.CnpjCpf(cnpj + cpf);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
