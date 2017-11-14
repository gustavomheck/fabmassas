using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Pais : EntityBase
    {
        public Pais()
        {
            Estados = new ObservableCollection<Estado>();
        }
        
        public int CodPais { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public virtual ICollection<Estado> Estados { get; set; }
    }
}
