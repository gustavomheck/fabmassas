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
    }
}
