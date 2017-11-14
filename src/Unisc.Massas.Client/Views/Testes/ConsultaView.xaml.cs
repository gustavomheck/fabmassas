using System.Windows;
using Unisc.Massas.Client.ViewModels;
using Unisc.Massas.Data.Repositorios;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.Views
{
    /// <summary>
    /// Interação lógica para ConsultaView.xaml
    /// </summary>
    public partial class ConsultaView : Window
    {
        public ConsultaView()
        {
            InitializeComponent();

            DataContext = new ConsultaViewModel<Empresa>(new EmpresaRepositorio());
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var view = new CadastroEmpresaView() { DataContext = DependencyFactory.Resolve<CadastroViewModel<Empresa>>() };
            //view.Owner = this;
            //view.ShowDialog();
        }
    }
}
