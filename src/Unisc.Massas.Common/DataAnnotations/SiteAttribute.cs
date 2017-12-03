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

            var pattern = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9]\.[^\s]{2,})";

            if (Regex.IsMatch(site, pattern, RegexOptions.IgnoreCase))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("O site informado não é válido.");
        }
    }
}
