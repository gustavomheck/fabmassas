using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroEncomendaViewModel : CadastroViewModelBase<Encomenda>
    {
        private readonly IEncomendaRepositorio encomendaRepositorio;
        private readonly IClienteRepositorio clienteRepositorio;

        public CadastroEncomendaViewModel(IEncomendaRepositorio encomendaRepositorio, IClienteRepositorio clienteRepositorio) : base(encomendaRepositorio, "Cadastro de Encomenda")
        {
            this.encomendaRepositorio = encomendaRepositorio;
            this.clienteRepositorio = clienteRepositorio;

            AdicionarTipoMassaCommand = new DelegateCommand(AdicionarTipoMassa);

            Carregar();
        }

        public Cliente[] Clientes { get; set; }
        public ICollection<Local> Locais => ClienteSelecionado?.Locais;
        public Cliente ClienteSelecionado { get; set; }
        public Local LocalSelecionado { get; set; }
        public ICommand AdicionarTipoMassaCommand { get; set; }

        protected override void Carregar()
        {
            base.Carregar();

            ApplicationHelper.ExecuteAction(new Action(
                () =>
                {
                    Clientes = clienteRepositorio.GetAllAsArray();
                }));
        }

        private async void AdicionarTipoMassa()
        {
            var view = new EscolherEncomendaView();
            var viewModel = new EscolherEncomendaViewModel();
            view.DataContext = viewModel;

            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value)
            {
                
            }
        }
    }
}
