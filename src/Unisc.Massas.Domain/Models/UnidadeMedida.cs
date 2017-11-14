using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class UnidadeMedida : EntityBase
    {
        public UnidadeMedida()
        {
            Produtos = new ObservableCollection<Produto>();
        }
        
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
