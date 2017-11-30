using System;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Domain.Models
{
    public class Estoque : EntityBase
    {
        public int ProdutoId { get; set; }

        [Range(0.00001, Double.MaxValue, ErrorMessage = "Informe a data de entrada")]
        public DateTime DataEntrada { get; set; }
        public DateTime? DataVencimento { get; set; }
        public decimal ValorProduto { get; set; }

        [Range(0.00001, Double.MaxValue, ErrorMessage = "Informe o valor do produto")]
        public decimal ValorUnidade { get; set; }

        [Range(0.00001, Double.MaxValue, ErrorMessage = "Informe a quantidade comprada")]
        public double QuantComprada { get; set; }
        public double QuantDisponivel { get; set; }

        [Required(ErrorMessage = "Informe o produto")]
        public virtual Produto Produto { get; set; }
    }
}
