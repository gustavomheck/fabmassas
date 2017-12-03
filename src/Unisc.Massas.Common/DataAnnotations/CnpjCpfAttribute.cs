using System;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CnpjCpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cnpjCpf = (string)value;

            if (String.IsNullOrEmpty(cnpjCpf))
            {
                return new ValidationResult("O CNPJ ou CPF informado não é válido.");
            }

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpjCpf = cnpjCpf.Trim();
            cnpjCpf = cnpjCpf.Replace(".", String.Empty).Replace("-", String.Empty).Replace("/", String.Empty);

            if (cnpjCpf.Length == 11)
            {
                string tempCpf = cnpjCpf.Substring(0, 9);

                int soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                }

                int resto = soma % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                string digito = resto.ToString();
                tempCpf = tempCpf + digito;

                soma = 0;

                for (int i = 0; i < 10; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                }

                resto = soma % 11;

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = digito + resto;

                if (cnpjCpf.EndsWith(digito))
                {
                    return ValidationResult.Success;
                }
            }

            if (cnpjCpf.Length == 14)
            {
                string tempCnpj = cnpjCpf.Substring(0, 12);
                int soma = 0;

                for (int i = 0; i < 12; i++)
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                }

                int resto = (soma % 11);

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                string digito = resto.ToString();
                tempCnpj = tempCnpj + digito;

                soma = 0;

                for (int i = 0; i < 13; i++)
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                }

                resto = (soma % 11);

                if (resto < 2)
                {
                    resto = 0;
                }
                else
                {
                    resto = 11 - resto;
                }

                digito = digito + resto;

                if (cnpjCpf.EndsWith(digito))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("O CNPJ ou CPF informado não é válido.");
        }
    }
}
