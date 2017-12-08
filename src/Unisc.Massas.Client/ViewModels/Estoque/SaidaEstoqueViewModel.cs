using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class SaidaEstoqueViewModel : ConsultaViewModelBase<Estoque>
    {
        private readonly IEstoqueRepositorio estoqueRepositorio;

        public SaidaEstoqueViewModel(IEstoqueRepositorio estoqueRepositorio)
            : base(estoqueRepositorio, "Produtos em Estoque", "Saída de Produto no Estoque")
        {
            this.estoqueRepositorio = estoqueRepositorio;
        }
    }
}
