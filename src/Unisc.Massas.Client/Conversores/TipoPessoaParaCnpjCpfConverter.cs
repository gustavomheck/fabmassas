using System;
using System.Globalization;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class TipoPessoaParaCnpjCpfConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = value as int? ?? -1;

            if (index == -1)
                return "Selecione o Tipo de Pessoa";
            if (index == 0)
                return "CPF";
            return "CNPJ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
