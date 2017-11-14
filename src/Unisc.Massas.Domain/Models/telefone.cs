using PropertyChanged;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Telefone : EntityBase
    {
        public int? EmpresaId { get; set; }
        public int? ClienteId { get; set; }
        public int Numero { get; set; }
        public string Observacao { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
