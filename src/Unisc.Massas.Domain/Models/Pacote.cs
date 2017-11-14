using PropertyChanged;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Pacote : EntityBase
    {
        public Pacote()
        {
        }

        public int EncomendaId { get; set; }
        public int TipoMassaId { get; set; }

        [Range(1, 100000)]
        public int Quantidade { get; set; }

        public virtual Encomenda Encomenda { get; set; }
        public virtual TipoMassa TipoMassa { get; set; }
    }
}
