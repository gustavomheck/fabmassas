using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroProdutoViewModel : CadastroViewModelBase<Produto>
    {
        private readonly IProdutoRepositorio produtoRepositorio;

        public CadastroProdutoViewModel(IProdutoRepositorio produtoRepositorio) : base(produtoRepositorio, "Cadastro de Produto")
        {
            this.produtoRepositorio = produtoRepositorio;
        }
    }
}
