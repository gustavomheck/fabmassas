using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TipoMassa : EntityBase
    {
        public TipoMassa()
        {
            //Encomendas = new ObservableCollection<Encomenda>();
            Ingredientes = new ObservableCollection<Produto>();
            Pacotes = new ObservableCollection<Pacote>();
        }
        
        public int FormaId { get; set; }
        public int MaquinaId { get; set; }

        [Required(ErrorMessage = "Informe o nome da massa")]
        public string NomeMassa { get; set; }

        [Range(0.00001, Double.MaxValue, ErrorMessage = "Informe o peso base")]
        public double PesoBase { get; set; }

        [Range(0.00001, Double.MaxValue, ErrorMessage = "Informe o valor base")]
        public decimal ValorBase { get; set; }

        [Required(ErrorMessage = "Selecione a Forma")]
        public virtual Forma Forma { get; set; }

        [Required(ErrorMessage = "Selecione a Máquina")]
        public virtual Maquina Maquina { get; set; }
        //public virtual ICollection<Encomenda> Encomendas { get; set; }

        public virtual ICollection<Pacote> Pacotes { get; set; }

        public virtual ICollection<Produto> Ingredientes { get; set; }

        public override IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>()
            {
                { "NomeMassa", "Nome" },
                { "Forma.Nome", "Forma" },
                { "Maquina.Nome", "Máquina" }
            };
        }

        public override bool Filtrar(object obj, string propertyName, string value)
        {
            var tipoMassa = (TipoMassa)obj;

            switch (propertyName)
            {
                case "NomeMassa":
                    return tipoMassa.NomeMassa.ToUpper().Contains(value.ToUpper());
                case "Forma.Nome":
                    return tipoMassa.Forma.Nome.ToUpper().Contains(value.ToUpper());
                case "Maquina.Nome":
                    return tipoMassa.Maquina.Nome.ToUpper().Contains(value.ToUpper());
                default:
                    return true;
            }
        }

        public override void ExcluirRelacionamentos()
        {
            base.ExcluirRelacionamentos();

            Ingredientes.Clear();
        }

        public override bool PodeExcluir(out string motivo)
        {
            motivo = "Esta massa não pode ser excluída porque possui encomendas";
            return !Pacotes.Any();
        }
    }
}
