using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Usuario : EntityBase
    {
        public Usuario()
        {
            FuncoesUsuario = new ObservableCollection<FuncaoUsuario>();
        }
        
        public string LoginUsuario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool IsSuperAdmin { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual ICollection<FuncaoUsuario> FuncoesUsuario { get; set; }
    }
}
