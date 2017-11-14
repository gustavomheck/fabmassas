using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Unisc.Massas.Client.Views
{
    /// <summary>
    /// Lógica interna para VerticalTabControl.xaml
    /// </summary>
    public partial class VerticalTabControl : Window
    {
        public VerticalTabControl()
        {
            InitializeComponent();

            content.Content = new CadastroEncomendaView();
        }
    }
}
