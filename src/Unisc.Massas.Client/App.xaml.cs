using System.Windows;
using Unisc.Massas.Client.ViewModels;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Data.Context;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Data.Repositorios;

namespace Unisc.Massas.Client
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
#if DEBUG
            DatabaseSeeder.Seed();
#endif

            // Para testes irá pegar a primeira empresa.
            IEmpresaRepositorio repositorio = new EmpresaRepositorio();
            IoC.EmpresaEmitente = repositorio.GetById(1);

            var mainWnd = new MainWindow()
            {
                DataContext = DependencyFactory.Resolve<MainWindowViewModel>()
            };

            mainWnd.ShowDialog();
        }
    }
}
