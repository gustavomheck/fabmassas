using System;
using System.Globalization;
using System.Windows.Data;

namespace Unisc.Massas.Client.Conversores
{
    public class InscricaoEstadualFormatter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var ie = (string)values[0] ?? "";
            var cep = values[1] as int?;
            
            if (cep.HasValue)
            {
                var uf = GetUfByCep(cep.Value);

                switch (uf)
                {
                    case "ACRE":
                    case "AC":
                        if (ie.Length == 13)
                            return String.Format("{0}.{1}.{2}/{3}-{4}", ie.Substring(0, 2), ie.Substring(2, 3), ie.Substring(5, 3), ie.Substring(8, 3), ie.Substring(11, 2));

                        break;
                    case "AMAZONAS":
                    case "AM":
                        if (ie.Length == 9)
                            return String.Format("{0}.{1}.{2}-{3}", ie.Substring(0, 2), ie.Substring(2, 3), ie.Substring(5, 3), ie.Substring(8, 1));

                        break;
                    case "BAHIA":
                    case "BA":
                        if (ie.Length == 8)
                            return String.Format("{0}-{1}", ie.Substring(0, 6), ie.Substring(6, 2));

                        break;
                    case "CEARA":
                    case "PARAIBA":
                    case "CE":
                    case "PB":
                        if (ie.Length == 9)
                            return String.Format("{0}-{1}", ie.Substring(0, 8), ie.Substring(8, 1));

                        break;
                    case "DISTRITO FEDERAL":
                    case "DF":
                        if (ie.Length == 13)
                            return String.Format("{0}.{1}.{2}-{3}", ie.Substring(0, 2), ie.Substring(2, 6), ie.Substring(8, 3), ie.Substring(11, 2));

                        break;
                    case "MATO GROSSO":
                    case "MT":
                        if (ie.Length == 11)
                            return String.Format("{0}-{1}", ie.Substring(0, 10), ie.Substring(10, 1));

                        break;
                    case "MINAS GERAIS":
                    case "MG":
                        if (ie.Length == 13)
                            return String.Format("{0}.{1}.{2}/{3}", ie.Substring(0, 3), ie.Substring(3, 3), ie.Substring(6, 3), ie.Substring(9));
                        if (ie.Length == 11)
                            return String.Format("{0}.{1}.{2}.{3}", ie.Substring(0, 3), ie.Substring(3, 3), ie.Substring(6, 3), ie.Substring(9, 2));
                        break;
                    case "PARA":
                    case "PA":
                        if (ie.Length == 9)
                            return String.Format("{0}-{1}-{2}", ie.Substring(0, 2), ie.Substring(2, 6), ie.Substring(8, 1));

                        break;
                    case "PARANA":
                    case "RORAIMA":
                    case "SERGIPE":
                    case "PR":
                    case "RR":
                    case "SE":
                        if (ie.Length == 10)
                            return String.Format("{0}-{1}", ie.Substring(0, 8), ie.Substring(8, 2));

                        break;
                    case "PERNAMBUCO":
                    case "PE":
                        if (ie.Length == 9)
                            return String.Format("{0}-{1}", ie.Substring(0, 7), ie.Substring(7, 2));

                        break;
                    case "RIO DE JANEIRO":
                    case "RJ":
                        if (ie.Length == 8)
                            return String.Format("{0}.{1}.{2}-{3}", ie.Substring(0, 2), ie.Substring(2, 3), ie.Substring(5, 2), ie.Substring(7, 1));

                        break;
                    case "RIO GRANDE DO NORTE":
                    case "RN":
                        if (ie.Length == 9)
                            return String.Format("{0}.{1}.{2}-{3}", ie.Substring(0, 2), ie.Substring(2, 3), ie.Substring(5, 3), ie.Substring(8, 1));

                        if (ie.Length == 10)
                            return String.Format("{0}.{1}.{2}.{3}-{4}", ie.Substring(0, 2), ie.Substring(2, 1), ie.Substring(3, 3), ie.Substring(6, 3), ie.Substring(9, 1));

                        break;
                    case "RIO GRANDE DO SUL":
                    case "RS":
                        if (ie.Length == 10)
                            return String.Format("{0}/{1}", ie.Substring(0, 3), ie.Substring(3, 7));

                        break;
                    case "RONDONIA":
                    case "RO":
                        if (ie.Length == 14)
                            return String.Format("{0}-{1}", ie.Substring(0, 13), ie.Substring(13, 1));

                        break;
                    case "SANTA CATARINA":
                    case "SC":
                        if (ie.Length == 9)
                            return String.Format("{0}.{1}.{2}", ie.Substring(0, 3), ie.Substring(3, 3), ie.Substring(6, 3));

                        break;
                    case "SAO PAULO":
                    case "SP":
                        if (ie.Length == 12)
                            return String.Format("{0}.{1}.{2}.{3}", ie.Substring(0, 3), ie.Substring(3, 3), ie.Substring(6, 3), ie.Substring(9, 3));

                        break;
                    default:
                        return ie;
                }
            }

            return String.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
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
