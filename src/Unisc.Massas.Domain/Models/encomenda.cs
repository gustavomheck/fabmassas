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
        public virtual ObservableCollection<Pacote> Pacotes { get; set; }

        public void AdicionarPacote(TipoMassa tipoMassa, int quantidade)
        {
            QuantPacotes += quantidade;
            Pacotes.Add(new Pacote()
            {
                TipoMassa = tipoMassa,
                TipoMassaId = tipoMassa.Id,
                Encomenda = this,
                EncomendaId = Id,
                Quantidade = quantidade
            });
        }

        public void RemoverPacote(Pacote pacote)
        {
            QuantPacotes -= pacote.Quantidade;
            Pacotes.Remove(pacote);
        }
    }
}
