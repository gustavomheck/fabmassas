using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroEncomendaViewModel : CadastroViewModelBase<Encomenda>
    {
        public CadastroEncomendaViewModel(IEncomendaRepositorio encomendaRepositorio) : base(encomendaRepositorio, "Cadastro de Encomenda")
        {
            AdicionarTipoMassaCommand = new DelegateCommand(AdicionarTipoMassa);
        }

        public ICommand AdicionarTipoMassaCommand { get; set; }

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
