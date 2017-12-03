using System;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpf = (string)value;

            if (String.IsNullOrEmpty(cpf))
            {
                return ValidationResult.Success;
            }

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", String.Empty).Replace("-", String.Empty).Replace("/", String.Empty);

            if (cpf.Length != 11)
            {
                return new ValidationResult("O CPF informado não é válido.");
            }

            var peso1 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var soma = 0;

            for (int i = 1; i < peso1.Length; i++)
            {
                soma += Convert.ToInt32(cpf[i - 1].ToString()) * peso1[i];
            }

            int dv1 = 11 - (soma % 11);

            if (dv1 == 10 || dv1 == 11)
                dv1 = 0;

            soma = 0;
            string tmpCpf = cpf + dv1;

            for (int i = 0; i < peso1.Length; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * peso1[i];
            }

            int dv2 = 11 - (soma % 11);

            if (dv2 == 10 || dv2 == 11)
                dv2 = 0;

            if (cpf[10].ToString() == dv2.ToString())
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("O CPF informado não é válido.");
        }
    }
}
