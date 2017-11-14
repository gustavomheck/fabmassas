using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Cliente : EntityBase
    {
        public Cliente()
        {
            Encomendas = new ObservableCollection<Encomenda>();
            Locais = new ObservableCollection<Local>();
            Telefones = new ObservableCollection<Telefone>();
        }
        
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public string InscEstadual { get; set; }
        public string InscMunicipal { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Encomenda> Encomendas { get; set; }
        public virtual ICollection<Local> Locais { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
