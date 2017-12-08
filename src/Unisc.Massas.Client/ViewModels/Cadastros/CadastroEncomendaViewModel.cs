using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
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

        public override Encomenda EntidadeSelecionada
        {
            get => _entidadeSelecionada;
            set
            {
                if (value != null)
                {
                    ClienteSelecionado = value.Cliente;
                    LocalSelecionado = value.Local;
                }

                SetValue(ref _entidadeSelecionada, value);
            }
        }

        public ObservableCollection<Pacote> Pacotes { get; set; }

        public Cliente[] Clientes { get; set; }
        public ICollection<Local> Locais => ClienteSelecionado?.Locais;

        [Required(ErrorMessage = "Informe o cliente")]
        public Cliente ClienteSelecionado { get; set; }

        [Required(ErrorMessage = "Informe o local de entrega da encomenda")]
        public Local LocalSelecionado { get; set; }
        public Pacote PacoteSelecionado { get; set; }
        public ObservableCollection<string> Status { get; set; }
        public ICommand AdicionarPacoteCommand { get; set; }
        public ICommand RemoverPacoteCommand { get; set; }

        protected override void Carregar()
        {
            base.Carregar();

            ApplicationHelper.ExecuteAction(new Action(
                () =>
                {
                    Clientes = clienteRepositorio.GetAllAsArray();
                    Status = new ObservableCollection<string>()
                    {
                        "Pendente",
                        "Em Produção",
                        "Entregue"
                    };
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

        protected override void Limpar()
        {
            base.Limpar();
            ClienteSelecionado = null;
            LocalSelecionado = null;
        }

        protected override void Salvar()
        {
            if (LocalSelecionado != null)
            {
                EntidadeSelecionada.Cliente = ClienteSelecionado;
                EntidadeSelecionada.ClienteId = ClienteSelecionado.Id;
                EntidadeSelecionada.Local = LocalSelecionado;
                EntidadeSelecionada.LocalId = LocalSelecionado.Id;
            }

            EntidadeSelecionada.Empresa = IoC.EmpresaEmitente;
            EntidadeSelecionada.EmpresaId = IoC.EmpresaEmitente.Id;

            base.Salvar();
        }
    }
}
