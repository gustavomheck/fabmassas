using PropertyChanged;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class PermissaoFuncao : EntityBase
    {
        public int FuncaoId { get; set; }
        public int PermissaoId { get; set; }
        public virtual Funcao Funcao { get; set; }
        public virtual Permissao Permissao { get; set; }
    }
}
