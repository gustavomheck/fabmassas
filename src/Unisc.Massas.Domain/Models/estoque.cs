using System;

namespace Unisc.Massas.Domain.Models
{
    public class Estoque : EntityBase
    {
        public int ProdutoId { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal ValorProduto { get; set; }
        public decimal ValorUnidade { get; set; }
        public double QuantComprada { get; set; }
        public double QuantDisponivel { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
