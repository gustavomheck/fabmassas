using System.Linq;
using System.Windows;
using Unisc.Massas.Client.ViewModels;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Data.Context;

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
            var mainWnd = new MainWindow()
            {
                DataContext = DependencyFactory.Resolve<MainWindowViewModel>()
            };

            mainWnd.ShowDialog();
        }
    }
}
