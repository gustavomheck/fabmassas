using System;
using System.Globalization;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class InscricaoEstadualFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ie = value as string;

            if (ie != null && ie.Length == 10)
                return String.Format("{0}/{1}", ie.Substring(0, 3), ie.Substring(3, 7));

            return ie;
        }        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public string GetUfByCep(int cep)
        {
            if (cep >= 69900000 && cep <= 69999999)
                return "AC";

            if (cep >= 57000000 && cep <= 57999999)
                return "AL";

            if ((cep >= 69000000 && cep <= 69299999) ||
                (cep >= 69400000 && cep <= 69899999))
                return "AM";

            if (cep >= 68900000 && cep <= 68999999)
                return "AP";

            if (cep >= 40000000 && cep <= 48999999)
                return "BA";

            if (cep >= 60000000 && cep <= 63999999)
                return "CE";

            if ((cep >= 70000000 && cep <= 72799999) ||
                (cep >= 73000000 && cep <= 73699999))
                return "DF";

            if (cep >= 29000000 && cep <= 29999999)
                return "ES";

            if ((cep >= 72800000 && cep <= 72999999) ||
                (cep >= 73700000 && cep <= 76799999))
                return "GO";

            if (cep >= 65000000 && cep <= 65999999)
                return "MA";

            if (cep >= 30000000 && cep <= 39999999)
                return "MG";

            if (cep >= 79000000 && cep <= 79999999)
                return "MS";

            if (cep >= 78000000 && cep <= 78899999)
                return "MT";

            if (cep >= 66000000 && cep <= 68899999)
                return "PA";

            if (cep >= 58000000 && cep <= 58999999)
                return "PB";

            if (cep >= 50000000 && cep <= 56999999)
                return "PE";

            if (cep >= 64000000 && cep <= 64999999)
                return "PI";

            if (cep >= 80000000 && cep <= 87999999)
                return "PR";

            if (cep >= 20000000 && cep <= 28999999)
                return "RJ";

            if (cep >= 59000000 && cep <= 59999999)
                return "RN";

            if (cep >= 76800000 && cep <= 76999999)
                return "RO";

            if (cep >= 69300000 && cep <= 69399999)
                return "RR";

            if (cep >= 90000000 && cep <= 99999999)
                return "RS";

            if (cep >= 88000000 && cep <= 8999999)
                return "SC";

            if (cep >= 49000000 && cep <= 49999999)
                return "SE";

            if (cep >= 1000000 && cep <= 19999999)
                return "SP";

            if (cep >= 77000000 && cep <= 77999999)
                return "TO";

            return String.Empty;
        }
    }
}
