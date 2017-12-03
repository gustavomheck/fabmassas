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
            //if (comboBoxTipoPessoa.SelectedIndex == -1)
            //{
            //    HintAssist.SetHint(textBoxCnpjCpf, "Selecione o Tipo de Pessoa");
            //    textBoxCnpjCpf.InputMask = "";
            //}
            //else if (comboBoxTipoPessoa.SelectedIndex == 0)
            //{
            //    HintAssist.SetHint(textBoxCnpjCpf, "CPF");
            //    textBoxCnpjCpf.InputMask = "000.000.000-00";
            //}
            //else if (comboBoxTipoPessoa.SelectedIndex == 1)
            //{
            //    HintAssist.SetHint(textBoxCnpjCpf, "CNPJ");
            //    textBoxCnpjCpf.InputMask = "00.000.000/0000-00";
            //}
            //if (comboBoxTipoPessoa.SelectedIndex == -1)
            //{
            //    HintAssist.SetHint(textBoxCpf, "Selecione o Tipo de Pessoa");
            //    textBoxCpf.Visibility = Visibility.Visible;
            //    textBoxCnpj.Visibility = Visibility.Collapsed;
            //}                
            //if (comboBoxTipoPessoa.SelectedIndex == 0)
            //{
            //    HintAssist.SetHint(textBoxCnpj, "CNPJ");
            //    textBoxCnpj.Visibility = Visibility.Visible;
            //    textBoxCpf.Visibility = Visibility.Collapsed;
            //}
            //else if (comboBoxTipoPessoa.SelectedIndex == 1)
            //{
            //    HintAssist.SetHint(textBoxCpf, "CPF");
            //    textBoxCpf.Visibility = Visibility.Visible;
            //    textBoxCnpj.Visibility = Visibility.Collapsed;
            //}       
        }
    }
}
