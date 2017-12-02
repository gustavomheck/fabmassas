using System.Windows;
using System.Windows.Controls;
using Unisc.Massas.Client.ViewModels;

namespace Unisc.Massas.Client.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = DependencyFactory.Resolve<MainWindowViewModel>();

            Loaded += (s, e) => Dashboard.IsChecked = true;
            sair.Click += (s, e) => Close();

            tabControl.SelectionChanged += TabControl_SelectionChanged;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                DesabilitarOpcoesCadastros();
                DesabilitarOpcoesConsultas();
                DesabilitarOpcoesEstoque();
            }
            else if (tabControl.SelectedIndex == 1)
            {
                DesabilitarOpcoesInicio();
                DesabilitarOpcoesConsultas();
                DesabilitarOpcoesEstoque();
            }
            else if (tabControl.SelectedIndex == 2)
            {
                DesabilitarOpcoesInicio();
                DesabilitarOpcoesCadastros();
                DesabilitarOpcoesEstoque();
            }
            else
            {
                DesabilitarOpcoesInicio();
                DesabilitarOpcoesCadastros();
                DesabilitarOpcoesConsultas();
            }
        }

        private void DesabilitarOpcoesInicio()
        {
            Dashboard.IsChecked = false;
            Ajuda.IsChecked = false;
        }

        private void DesabilitarOpcoesCadastros()
        {
            CadastroCliente.IsChecked = false;
            CadastroEmpresa.IsChecked = false;
            CadastroEncomenda.IsChecked = false;
            CadastroForma.IsChecked = false;
            CadastroMaquina.IsChecked = false;
            CadastroProduto.IsChecked = false;
            CadastroTipoMassa.IsChecked = false;
            CadastroUnidadeMedida.IsChecked = false;
        }

        private void DesabilitarOpcoesConsultas()
        {
            ConsultaClientes.IsChecked = false;
            ConsultaEmpresas.IsChecked = false;
            ConsultaEncomendas.IsChecked = false;
            ConsultaEstoque.IsChecked = false;
            ConsultaFormas.IsChecked = false;
            ConsultaMaquinas.IsChecked = false;
            ConsultaTiposMassa.IsChecked = false;
            ConsultaUnidadesMedida.IsChecked = false;
        }

        private void DesabilitarOpcoesEstoque()
        {
            EntradaEstoque.IsChecked = false;
            SaidaEstoque.IsChecked = false;
        }
    }
}
