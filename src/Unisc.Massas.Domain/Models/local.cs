using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Unisc.Massas.Core.Texto;

namespace Unisc.Massas.Domain.Models
{
    public class Local : EntityBase
    {
        public int ClienteId { get; set; }
        public int Cep { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o n�mero")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public virtual Cliente Cliente { get; set; }

        public override IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>()
            {
                { "Cep", "CEP" },
                { "Cidade", "Cidade" },
                { "Logradouro", "Logradouro" },
                { "Bairro", "Bairro" },
                { "Complemento", "Complemento" }
            };
        }

        public override bool Filtrar(object obj, string propertyName, string value)
        {
            var local = (Local)obj;

            switch (propertyName)
            {
                case "Cep":
                    return local.Cep.ToString().Contains(value);
                case "Cidade":
                    return local.Cidade.ToUpper().Contains(value.ToUpper());
                case "Logradouro":
                    return local.Logradouro.ToUpper().Contains(value.ToUpper());
                case "Bairro":
                    return local.Bairro.ToUpper().Contains(value.ToUpper());
                case "Complemento":
                    return local.Complemento.ToUpper().Contains(value.ToUpper());
                default:
                    return true;
            }
        }

        public override string ToString()
        {
            string resultado = $"{Formatar.Cep(Cep)} - {Logradouro}, {Numero}";

            if (!String.IsNullOrWhiteSpace(Complemento))
            {
                resultado += ", " + Complemento;
            }

            resultado += $", {Bairro} - {Cidade}";

            return resultado;
        }
    }
}
