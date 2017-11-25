using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroProdutoViewModel : CadastroViewModelBase<Produto>
    {
        private readonly IProdutoRepositorio produtoRepositorio;
        private readonly IUnidadeMedidaRepositorio unidadeMedidaRepositorio;

        public CadastroProdutoViewModel(IProdutoRepositorio produtoRepositorio, IUnidadeMedidaRepositorio unidadeMedidaRepositorio) : base(produtoRepositorio, "Cadastro de Produto")
        {
            this.produtoRepositorio = produtoRepositorio;
            this.unidadeMedidaRepositorio = unidadeMedidaRepositorio;

            CadastrarUnidadeMedidaCommand = new DelegateCommand(CadastrarUnidadeMedida);

            Carregar();
        }

        public UnidadeMedida[] UnidadesMedida { get; set; }
        public ICommand CadastrarUnidadeMedidaCommand { get; set; }

        protected override void Carregar()
        {
            base.Carregar();

            ApplicationHelper.ExecuteAction(new Action(
                async () =>
                {
                    UnidadesMedida = await unidadeMedidaRepositorio.GetAllAsArrayAsync();
                }));
        }

        private async void CadastrarUnidadeMedida()
        {
            var viewModel = new ModalViewModelBase<UnidadeMedida>();
            var view = new AdicionarUnidadeMedidaView()
            {
                DataContext = viewModel
            };
            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value && unidadeMedidaRepositorio.Insert(viewModel.EntidadeSelecionada, out string msgErro))
            {
                UnidadesMedida = await unidadeMedidaRepositorio.GetAllAsArrayAsync();
                EntidadeSelecionada.UnidadeMedida = viewModel.EntidadeSelecionada;
            }
        }
    }
}
