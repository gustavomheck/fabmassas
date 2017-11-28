using System.Windows;
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

            //content.Content = new DashboardView()
            //{
            //    DataContext = DependencyFactory.Resolve<DashboardViewModel>()
            //};
        }
    }
}
