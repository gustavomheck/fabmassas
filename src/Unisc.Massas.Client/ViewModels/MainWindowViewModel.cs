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
        }
    }
}
