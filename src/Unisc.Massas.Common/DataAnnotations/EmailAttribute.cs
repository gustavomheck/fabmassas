using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Unisc.Massas.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = (string)value;

            if (String.IsNullOrEmpty(email))
            {
                return ValidationResult.Success;
            }

            string pattern = @"^[a-z|0-9][a-z|0-9]*([_'-][a-z|0-9]+)*" +
                             @"(([.][a-z|0-9]+)+([_'-][a-z|0-9]+)*)?@" +
                             @"[a-z|0-9][a-z|0-9]*([-][a-z|0-9]+)*" +
                             @"(([.][a-z|0-9]+)+([-][a-z|0-9]+)*)$";

            if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("O e-mail informado não é válido.");
        }
    }
}
