using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Unisc.Massas.Domain.Models
{
    public class Encomenda : EntityBase
    {
        public Encomenda()
        {
            DataPedido = DateTime.Now;
            //TiposMassas = new ObservableCollection<TipoMassa>();
            Pacotes = new ObservableCollection<Pacote>();
        }
        
        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double Peso { get; set; }
        public decimal Valor { get; set; }
        public int QuantPacotes { get; set; }
        public int Status { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
        //public virtual ICollection<TipoMassa> TiposMassas { get; set; }
        public virtual ICollection<Pacote> Pacotes { get; set; }
    }
}
