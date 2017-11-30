using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

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
        }

        public ICommand AdicionarLocalCommand { get; set; }
        public ICommand AdicionarTelefoneCommand { get; set; }
        public ICommand EditarLocalCommand { get; set; }
        public ICommand EditarTelefoneCommand { get; set; }
        public ICommand RemoverLocalCommand { get; set; }
        public ICommand RemoverTelefoneCommand { get; set; }

        public async void AdicionarLocal()
        {
            var viewModel = new AdicionarLocalViewModel();
            var view = new AdicionarLocalView()
            {
                DataContext = viewModel
            };
            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value)
            {
                EntidadeSelecionada.Locais.Add(viewModel.EntidadeSelecionada);
            }
        }

        public async void AdicionarTelefone()
        {
            var viewModel = new AdicionarTelefoneViewModel();
            var view = new AdicionarTelefoneView()
            {
                DataContext = viewModel
            };
            var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

            if (result.HasValue && result.Value)
            {
                EntidadeSelecionada.Telefones.Add(viewModel.EntidadeSelecionada);
            }
        }
    }
}
