using System;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IEAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }
}
