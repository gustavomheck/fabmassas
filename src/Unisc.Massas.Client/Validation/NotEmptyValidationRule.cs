using System.Globalization;
using System.Windows.Controls;

namespace Unisc.Massas.Client.Validation
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "O campo é obrigatório.")
                : ValidationResult.ValidResult;
        }
    }
}
