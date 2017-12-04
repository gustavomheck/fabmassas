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

            ContentRendered += (s, e) => Dashboard.IsChecked = true;
            sair.Click += (s, e) => Close();
        }
    }
}
