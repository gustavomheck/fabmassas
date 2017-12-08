using System;
using System.Globalization;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class StatusEncomendaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value as int?;

            if (status.HasValue)
            {
                if (status.Value == 0)
                    return "Pendente";

                if (status.Value == 1)
                    return "Em Produção";

                if (status.Value == 2)
                    return "Entregue";
            }

            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
