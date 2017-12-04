using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaProdutosViewModel : ConsultaViewModelBase<Produto>
    {
        private readonly IProdutoRepositorio produtoRepositorio;

        public ConsultaProdutosViewModel(IProdutoRepositorio produtoRepositorio) : base(produtoRepositorio, "Consulta de Produtos", "Edição de Produto")
        {
            this.produtoRepositorio = produtoRepositorio;
        }

        public CadastroProdutoViewModel CadastroProdutoViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroProdutoViewModel == null)
                CadastroProdutoViewModel = DependencyFactory.Resolve<CadastroProdutoViewModel>();

            CadastroProdutoViewModel.EntidadeSelecionada = produtoRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroProdutoViewModel.EntidadeSelecionada);
        }
    }
}
