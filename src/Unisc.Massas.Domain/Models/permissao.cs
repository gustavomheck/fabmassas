using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Permissao : EntityBase
    {
        public Permissao()
        {
            PermissoesFuncao = new ObservableCollection<PermissaoFuncao>();
        }
        
        public string TituloPermissao { get; set; }
        public string NomePermissao { get; set; }
        public virtual ICollection<PermissaoFuncao> PermissoesFuncao { get; set; }
    }
}
