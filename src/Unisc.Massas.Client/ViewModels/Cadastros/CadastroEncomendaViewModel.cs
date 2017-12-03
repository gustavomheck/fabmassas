using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly ITipoMassaRepositorio tipoMassaRepositorio;

        public CadastroEncomendaViewModel(
            IEncomendaRepositorio encomendaRepositorio,
            IClienteRepositorio clienteRepositorio,
            ITipoMassaRepositorio tipoMassaRepositorio) : base(encomendaRepositorio, "Cadastro de Encomenda")
        {
            this.encomendaRepositorio = encomendaRepositorio;
            this.clienteRepositorio = clienteRepositorio;
            this.tipoMassaRepositorio = tipoMassaRepositorio;

            AdicionarPacoteCommand = new DelegateCommand(AdicionarPacote);
            RemoverPacoteCommand = new DelegateCommand(RemoverPacote);

            Carregar();            
        }

        public ObservableCollection<Pacote> Pacotes { get; set; }

        public Cliente[] Clientes { get; set; }
        public ICollection<Local> Locais => ClienteSelecionado?.Locais;
        public Cliente ClienteSelecionado { get; set; }
        public Local LocalSelecionado { get; set; }
        public Pacote PacoteSelecionado { get; set; }
        public ICommand AdicionarPacoteCommand { get; set; }
        public ICommand RemoverPacoteCommand { get; set; }

        protected override void Carregar()
        {
            base.Carregar();

            ApplicationHelper.ExecuteAction(new Action(
                () =>
                {
                    Clientes = clienteRepositorio.GetAllAsArray();
                }));
        }

        private async void AdicionarPacote()
        {
            var view = new AdicionarMassaView();
            var viewModel = new AdicionarMassaViewModel(tipoMassaRepositorio);
            view.DataContext = viewModel;

            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value)
            {
                EntidadeSelecionada.AdicionarPacote(viewModel.TipoMassaSelecionado, viewModel.Quantidade);
            }
        }

        private async void RemoverPacote()
        {
            var view = new DialogView()
            {
                DataContext = new DialogViewModel("Tem certeza que deseja excluir o pacote?", "Excluir pacote", DialogResult.CancelDelete)
            };
            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value)
            {
                EntidadeSelecionada.RemoverPacote(PacoteSelecionado);
            }
        }
    }
}
