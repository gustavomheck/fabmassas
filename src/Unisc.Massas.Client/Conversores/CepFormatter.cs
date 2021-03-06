﻿using System;
using System.Globalization;
using System.Windows.Data;
using Unisc.Massas.Core.Texto;

namespace Unisc.Massas.Client.Conversores
{
    public class CepFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Formatar.Cep(value as int?);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
