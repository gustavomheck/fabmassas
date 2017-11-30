using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;
using System;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroClienteViewModel : CadastroViewModelBase<Cliente>
    {
        private readonly IClienteRepositorio clienteRepositorio;

        public CadastroClienteViewModel(IClienteRepositorio clienteRepositorio) : base(clienteRepositorio, "Cadastro de Cliente")
        {
            this.clienteRepositorio = clienteRepositorio;

            AdicionarLocalCommand = new DelegateCommand(AdicionarLocal);
            AdicionarTelefoneCommand = new DelegateCommand(AdicionarTelefone);
            EditarLocalCommand = new DelegateCommand(EditarLocal);
            EditarTelefoneCommand = new DelegateCommand(EditarTelefone);
            RemoverLocalCommand = new DelegateCommand(RemoverLocal);
            RemoverTelefoneCommand = new DelegateCommand(RemoverTelefone);
        }

        public Local LocalSelecionado { get; set; }
        public Telefone TelefoneSelecionado { get; set; }
        public ICommand AdicionarLocalCommand { get; set; }
        public ICommand AdicionarTelefoneCommand { get; set; }
        public ICommand EditarLocalCommand { get; set; }
        public ICommand EditarTelefoneCommand { get; set; }
        public ICommand RemoverLocalCommand { get; set; }
        public ICommand RemoverTelefoneCommand { get; set; }

        public async void AdicionarLocal()
        {
            var viewModel = new AdicionarLocalViewModel();
            var result = await AdicionarLocal(viewModel);

            if (result.HasValue && result.Value)
            {
                EntidadeSelecionada.Locais.Add(viewModel.EntidadeSelecionada);
            }
        }

        public async Task<bool?> AdicionarLocal(AdicionarLocalViewModel viewModel)
        {
            var view = new AdicionarLocalView()
            {
                DataContext = viewModel
            };
            return (bool?)(await DialogHost.Show(view, "RootDialog"));
        }

        private async void EditarLocal()
        {
            var viewModel = new AdicionarLocalViewModel(LocalSelecionado);
            await AdicionarLocal(viewModel);
        }

        private async void RemoverLocal()
        {
            if (LocalSelecionado != null)
            {
                bool? result = await ConfirmarExclusaoAsync("Local");

                if (result.HasValue && result.Value)
                    EntidadeSelecionada.Locais.Remove(LocalSelecionado);
            }
        }

        public async void AdicionarTelefone()
        {
            var viewModel = new AdicionarTelefoneViewModel();
            var result = await AdicionarTelefone(viewModel);

            if (result.HasValue && result.Value)
            {
                EntidadeSelecionada.Telefones.Add(viewModel.EntidadeSelecionada);
            }
        }

        public async Task<bool?> AdicionarTelefone(AdicionarTelefoneViewModel viewModel)
        {
            var view = new AdicionarTelefoneView()
            {
                DataContext = viewModel
            };
            return (bool?)(await DialogHost.Show(view, "RootDialog"));
        }

        private async void EditarTelefone()
        {
            var viewModel = new AdicionarTelefoneViewModel(TelefoneSelecionado);
            await AdicionarTelefone(viewModel);
        }

        private async void RemoverTelefone()
        {
            if (TelefoneSelecionado != null)
            {
                bool? result = await ConfirmarExclusaoAsync("Local");

                if (result.HasValue && result.Value)
                    EntidadeSelecionada.Telefones.Remove(TelefoneSelecionado);
            }
        }

        private async Task<bool?> ConfirmarExclusaoAsync(string registro)
        {
            var view = new DialogView()
            {
                DataContext = new DialogViewModel($"Tem certeza que deseja excluir este {registro}?", $"Excluir {registro}", DialogResult.CancelDelete)
            };
            return (bool?)(await DialogHost.Show(view, "RootDialog"));
        }
    }
}
