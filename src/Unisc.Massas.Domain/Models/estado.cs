using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Estado : EntityBase
    {
        public Estado()
        {
            Cidades = new ObservableCollection<Cidade>();
        }
        
        public int PaisId { get; set; }
        public int CodIbge { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
