using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    public class Forma : EntityBase
    {
        public Forma()
        {
            TiposMassas = new ObservableCollection<TipoMassa>();
        }
        
        public string Nome { get; set; }
        public virtual ICollection<TipoMassa> TiposMassas { get; set; }
    }
}
