using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace Unisc.Massas.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SiteAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var site = value as string;

            if (String.IsNullOrEmpty(site))
            {
                return ValidationResult.Success;
            }

            var pattern = @"/((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+" +
                          @"\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)/";

            if (Regex.IsMatch(site, pattern, RegexOptions.IgnoreCase))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("O site informado não é válido.");
        }
    }
}
