using System.Windows.Controls;
using System.Windows.Input;
using Unisc.Massas.Core.Extensions;
using Unisc.Massas.Core.Texto;

namespace Unisc.Massas.Client.Views
{
    /// <summary>
    /// Interação lógica para AdicionarTelefoneView.xaml
    /// </summary>
    public partial class AdicionarTelefoneView : UserControl
    {
        public AdicionarTelefoneView()
        {
            InitializeComponent();

            textBoxTelefone.KeyDown += TextBoxTelefone_KeyDown;
            textBoxTelefone.KeyUp += TextBoxTelefone_KeyUp;
            textBoxTelefone.TextChanged += TextBoxTelefone_TextChanged;
        }

        private void TextBoxTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !e.IsNumber();
        }

        private void TextBoxTelefone_KeyUp(object sender, KeyEventArgs e)
        {
            Formatar.MascaraTelefoneKeyUp(textBoxTelefone, ref e);
        }

        private void TextBoxTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Formatar.MascaraTelefoneTextChanged(textBoxTelefone);
        }
    }
}
