using System.Windows;
using Unisc.Massas.Client.ViewModels;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

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

            Loaded += (s, e) => Inicio.IsChecked = true;
            sair.Click += (s, e) => Close();
        }

        private void EmpresasOnClick(object sender, RoutedEventArgs e)
        {
            ShowWindow(new ConsultaView()
            {
                DataContext = new ConsultaViewModel<Empresa>(DependencyFactory.Resolve<IEmpresaRepositorio>())
                {
                    ViewName = "Empresas"
                }
            });
        }

        private void ShowWindow(Window wnd)
        {
            wnd.Closing += delegate
            {
                var main = new MainWindow();
                main.Show();
            };

            Close();
            wnd.ShowDialog();
        }

        private void EncomendasOnClick(object sender, RoutedEventArgs e)
        {
            //ShowWindow(new CadastroEncomendaView());
        }
    }
}
