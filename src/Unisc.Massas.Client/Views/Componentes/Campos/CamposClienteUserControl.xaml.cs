using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Windows;

namespace Unisc.Massas.Client.Views
{
    /// <summary>
    /// Interação lógica para CamposClienteUserControl.xaml
    /// </summary>
    public partial class CamposClienteUserControl : UserControl
    {
        public CamposClienteUserControl()
        {
            InitializeComponent();

            comboBoxTipoPessoa.SelectionChanged += ComboBoxTipoPessoa_SelectionChanged;
        }

        private void ComboBoxTipoPessoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxTipoPessoa.SelectedIndex == 1)
            {
                textBoxCnpj.Visibility = Visibility.Visible;
                textBoxInscEstadual.Visibility = Visibility.Visible;
                textBoxCpf.Visibility = Visibility.Collapsed;
            }
            else
            {
                textBoxCnpj.Visibility = Visibility.Collapsed;
                textBoxInscEstadual.Visibility = Visibility.Collapsed;
                textBoxCpf.Visibility = Visibility.Visible;
            }
        }
    }
}
