using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Unisc.Massas.Domain.Models
{
    public class Produto : EntityBase
    {
        public Produto()
        {
            Estoques = new ObservableCollection<Estoque>();
            TiposMassas = new ObservableCollection<TipoMassa>();
        }
        
        public int UnidadeMedidaId { get; set; }

        [Required(ErrorMessage = "Informe o c�digo do produto")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [Range(0.00001, Double.MaxValue, ErrorMessage = "Informe o valor base")]
        public decimal ValorBase { get; set; }
        public double QtdeMinimaEstoque { get; set; }
        public bool IsIngrediente { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }
        public virtual ICollection<Estoque> Estoques { get; set; }
        public virtual ICollection<TipoMassa> TiposMassas { get; set; }

        public override bool PodeExcluir(out string motivo)
        {
            if (TiposMassas.Any())
            {
                motivo = "Este produto n�o pode ser exclu�do porque possui encomendas";
                return false;
            }

            if (Estoques.Any())
            {
                motivo = "Este produto n�o pode ser exclu�do porque possui estoque";
                return false;
            }

            motivo = String.Empty;
            return true;
        }

        public override string ToString() => Nome + " - " + Codigo; 
    }
}
