using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    public class Funcao : EntityBase
    {
        public Funcao()
        {
            FuncoesUsuarios = new ObservableCollection<FuncaoUsuario>();
            PermissoesFuncao = new ObservableCollection<PermissaoFuncao>();
        }
        
        public string Titulo { get; set; }
        public virtual ICollection<FuncaoUsuario> FuncoesUsuarios { get; set; }
        public virtual ICollection<PermissaoFuncao> PermissoesFuncao { get; set; }
    }
}
