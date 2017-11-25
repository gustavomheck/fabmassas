using System;
using System.Windows.Controls;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core.Comandos;

namespace Unisc.Massas.Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _content;

        /// <summary>
        /// Inicializa uma nova instância da classe MainWindowViewModel.
        /// </summary>
        public MainWindowViewModel()
        {
            SelecionarOpcaoCommand = new DelegateCommand<string>(SelecionarOpcao);
        }

        /// <summary>
        /// 
        /// </summary>
        public object Content
        {
            get => _content;
            set => SetValue(ref _content, value);
        }

        public ICommand SelecionarOpcaoCommand { get; private set; }

        private void SelecionarOpcao(string op)
        {
            var uc = (UserControl)Activator.CreateInstance(Type.GetType("Unisc.Massas.Client.Views." + op + "View"));
            uc.DataContext = DependencyFactory.Resolve(Type.GetType("Unisc.Massas.Client.ViewModels." + op + "ViewModel"));
            Content = uc;

            //switch (op)
            //{
            //    case "CadastroEmpresa":
            //        Content = new CadastroEmpresaView()
            //        {
            //            DataContext = DependencyFactory.Resolve<CadastroEmpresaViewModel>()
            //        };
            //        break;
            //    case "CadastroEncomenda":
            //        Content = new CadastroEncomendaView()
            //        {
            //            DataContext = DependencyFactory.Resolve<CadastroEncomendaViewModel>()
            //        };
            //        break;
            //    case "CadastroCliente":
            //        Content = new CadastroClienteView()
            //        {
            //            DataContext = DependencyFactory.Resolve<CadastroClienteViewModel>()
            //        };
            //        break;
            //    case "CadastroProduto":
            //        Content = new CadastroProdutoView()
            //        {
            //            DataContext = DependencyFactory.Resolve<CadastroProdutoViewModel>()
            //        };
            //        break;
            //    case "CadastroTipoDeMassa":
            //        Content = new CadastroTipoMassaView()
            //        {
            //            DataContext = DependencyFactory.Resolve<CadastroTipoMassaViewModel>()
            //        };
            //        break;
            //    case "ConsultaEmpresas":
            //        Content = new ConsultaEmpresasView()
            //        {
            //            DataContext = DependencyFactory.Resolve<ConsultaEmpresasViewModel>()
            //        };
            //        break;
            //    case "ConsultaEncomendas":
            //        Content = new ConsultaEncomendasView()
            //        {
            //            DataContext = DependencyFactory.Resolve<ConsultaEncomendasViewModel>()
            //        };
            //        break;
            //    case "ConsultaClientes":
            //        Content = new ConsultaClientesView()
            //        {
            //            DataContext = DependencyFactory.Resolve<ConsultaClientesViewModel>()
            //        };
            //        break;
            //    case "ConsultaEstoque":
            //        Content = new ConsultaEstoqueView()
            //        {
            //            DataContext = DependencyFactory.Resolve<ConsultaEstoqueViewModel>()
            //        };
            //        break;
            //    case "ConsultaTiposDeMassa":
            //        Content = new ConsultaTiposMassaView()
            //        {
            //            DataContext = DependencyFactory.Resolve<ConsultaTiposMassaViewModel>()
            //        };
            //        break;
            //    case "EntradaDeEstoque":
            //        Content = new EntradaEstoqueView()
            //        {
            //            DataContext = DependencyFactory.Resolve<EntradaEstoqueViewModel>()
            //        };
            //        break;
            //    case "SaidaDeEstoque":
            //        Content = new SaidaEstoqueView()
            //        {
            //            DataContext = DependencyFactory.Resolve<SaidaEstoqueViewModel>()
            //        };
            //        break;
            //}
        }
    }
}
