using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal ValorBase { get; set; }
        public double QtdeMinimaEstoque { get; set; }
        public bool IsIngrediente { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }
        public virtual ICollection<Estoque> Estoques { get; set; }
        public virtual ICollection<TipoMassa> TiposMassas { get; set; }
        
        public IEnumerable<Produto> GetProdutos()
        {
            return new List<Produto>()
            {
                new Produto() { Nome = "Produto 1" },
                new Produto() { Nome = "Produto 2" },
                new Produto() { Nome = "Produto 3" },
                new Produto() { Nome = "Produto 4" },
                new Produto() { Nome = "Produto 5" },
                new Produto() { Nome = "Produto 6" },
                new Produto() { Nome = "Produto 7" },
                new Produto() { Nome = "Produto 8" },
                new Produto() { Nome = "Produto 9" },
                new Produto() { Nome = "Produto 10" },
                new Produto() { Nome = "Produto 11" },
                new Produto() { Nome = "Produto 12" },
                new Produto() { Nome = "Produto 13" },
                new Produto() { Nome = "Produto 14" },
                new Produto() { Nome = "Produto 15" },
            };
        }
    }
}
