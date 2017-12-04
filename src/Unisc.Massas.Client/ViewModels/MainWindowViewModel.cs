using System;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using Unisc.Massas.Core.Comandos;

namespace Unisc.Massas.Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private PropertyInfo[] _radioButtons;

        /// <summary>
        /// Inicializa uma nova instância da classe MainWindowViewModel.
        /// </summary>
        public MainWindowViewModel()
        {
            _radioButtons = GetType().GetProperties().Where(p => p.PropertyType == typeof(bool)).ToArray();
            SelecionarOpcaoCommand = new DelegateCommand<string>(SelecionarOpcao);
        }

        /// <summary>
        /// Obtém ou define o conteúdo da janela principal do programa.
        /// </summary>
        public object Content { get; set; }

        public bool DashboardIsChecked { get; set; }
        public bool AjudaIsChecked { get; set; }
        public bool CadastroClienteIsChecked { get; set; }
        public bool CadastroEmpresaIsChecked { get; set; }
        public bool CadastroEncomendaIsChecked { get; set; }
        public bool CadastroFormaIsChecked { get; set; }
        public bool CadastroMaquinaIsChecked { get; set; }
        public bool CadastroProdutoIsChecked { get; set; }
        public bool CadastroTipoMassaIsChecked { get; set; }
        public bool CadastroUnidadeMedidaIsChecked { get; set; }
        public bool ConsultaClientesIsChecked { get; set; }
        public bool ConsultaEmpresasIsChecked { get; set; }
        public bool ConsultaEncomendasIsChecked { get; set; }
        public bool ConsultaEstoqueIsChecked { get; set; }
        public bool ConsultaFormasIsChecked { get; set; }
        public bool ConsultaLocaisIsChecked { get; set; }
        public bool ConsultaMaquinasIsChecked { get; set; }
        public bool ConsultaProdutosIsChecked { get; set; }
        public bool ConsultaTiposMassaIsChecked { get; set; }
        public bool ConsultaUnidadesMedidaIsChecked { get; set; }
        public bool EntradaEstoqueIsChecked { get; set; }
        public bool SaidaEstoqueIsChecked { get; set; }

        public int TabIndex { get; set; }

        public ICommand SelecionarOpcaoCommand { get; private set; }

        /// <summary>
        /// Método chamado quando o usuário clica em uma das opções do
        /// menu lateral.
        /// </summary>
        /// <param name="op">A o nome da View chamada.</param>
        private void SelecionarOpcao(string op)
        {
            var uc = (UserControl)Activator.CreateInstance(Type.GetType("Unisc.Massas.Client.Views." + op + "View"));
            uc.DataContext = DependencyFactory.Resolve(Type.GetType("Unisc.Massas.Client.ViewModels." + op + "ViewModel"));
            Content = uc;

            for (int i = 0; i < _radioButtons.Length; i++)
            {
                if (!_radioButtons[i].Name.Equals(op + "IsChecked"))
                {
                    _radioButtons[i].SetValue(this, false);
                }                
            }

            if (op.StartsWith("Cadastro"))
                TabIndex = 1;
            else if (op.StartsWith("Consulta"))
                TabIndex = 2;
            else if (op.EndsWith("Estoque"))
                TabIndex = 3;
        }
    }
}
