using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroEstoqueViewModel : CadastroViewModelBase<Estoque>
    {
        private readonly IEstoqueRepositorio estoqueRepositorio;

        public CadastroEstoqueViewModel(IEstoqueRepositorio estoqueRepositorio) : base(estoqueRepositorio, "Cadastro de Estoque")
        {
            this.estoqueRepositorio = estoqueRepositorio;
        }
    }
}
