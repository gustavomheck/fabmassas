using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Unisc.Massas.Core.DataAnnotations;

namespace Unisc.Massas.Domain.Models
{
    public class Empresa : EntityBase
    {
        public Empresa()
        {
            Encomendas = new ObservableCollection<Encomenda>();
            Telefones = new ObservableCollection<Telefone>();
        }
        
        [Cnpj]
        [Display(Name = "CNPJ")]
        [Required]
        public string Cnpj { get; set; }

        public string InscEstadual { get; set; }
        public string InscMunicipal { get; set; }

        [Display(Name = "Razão Social")]
        [Required]
        public string RazaoSocial { get; set; }
        public string Apelido { get; set; }
        public string Logomarca { get; set; }

        [Range(1000000, 99999999, ErrorMessage = "O campo CEP é obrigatório")]
        public int Cep { get; set; }
        
        [Required]
        public string Bairro { get; set; }
        
        [Required]
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        [Site]
        public string Site { get; set; }

        [Email]
        public string Email { get; set; }
        public virtual ICollection<Encomenda> Encomendas { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        
        public override IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>()
            {
                { "Cnpj", "CNPJ" },
                { "RazaoSocial", "Razão Social" },
                { "Cep", "CEP" },
                { "Logradouro", "Logradouro" },
                { "Bairro", "Bairro" }
            };
        }

        public override bool Filtrar(object obj, string propertyName, string value)
        {
            var empresa = (Empresa)obj;

            switch (propertyName)
            {
                case "Cnpj":
                    return empresa.Cnpj.Contains(value);
                case "RazaoSocial":
                    return empresa.RazaoSocial.ToUpper().Contains(value.ToUpper());
                case "Cep":
                    return empresa.Cep.ToString().Contains(value);
                case "Logradouro":
                    return empresa.Logradouro.ToUpper().Contains(value.ToUpper());
                case "Bairro":
                    return empresa.Bairro.ToUpper().Contains(value.ToUpper());
                default:
                    return true;
            }
        }

        public override bool PodeExcluir(out string motivo)
        {
            motivo = "A empresa não pode ser excluída porque ele possui encomendas.";
            return Encomendas.Any();
        }

        public override string ToString()
        {
            return RazaoSocial;
        }        
    }
}
