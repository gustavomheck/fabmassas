using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Unisc.Massas.Core.DataAnnotations;

namespace Unisc.Massas.Domain.Models
{
    public class Cliente : EntityBase
    {
        public Cliente()
        {
            Encomendas = new ObservableCollection<Encomenda>();
            Locais = new ObservableCollection<Local>();
            Telefones = new ObservableCollection<Telefone>();
        }
        
        [Cnpj]
        public string Cnpj { get; set; }

        [Cpf]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente")]
        public string Nome { get; set; }

        [IE]
        public string InscEstadual { get; set; }
        public string InscMunicipal { get; set; }

        [Site]
        public string Site { get; set; }

        [Email]
        public string Email { get; set; }

        public virtual ICollection<Encomenda> Encomendas { get; set; }
        public virtual ICollection<Local> Locais { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }

        public override IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>()
            {
                { "CnpjCpf", "CNPJ/CPF" },
                { "Nome", "Nome" }
            };
        }

        public override bool Filtrar(object obj, string propertyName, string value)
        {
            var cliente = (Cliente)obj;

            switch (propertyName)
            {
                case "CnpjCpf":
                    if (cliente.Cnpj != null)
                        return cliente.Cpf.Contains(value) || cliente.Cnpj.Contains(value);
                    return false;
                case "Nome":
                    return cliente.Nome.ToUpper().Contains(value.ToUpper());
                default:
                    return true;
            }
        }

        public override void ExcluirRelacionamentos()
        {
            base.ExcluirRelacionamentos();

            Locais.Clear();
            Telefones.Clear();
        }

        public override bool PodeExcluir(out string motivo)
        {
            motivo = "O cliente não pode ser excluído porque ele possui encomendas.";
            return !Encomendas.Any();
        }
    }
}
