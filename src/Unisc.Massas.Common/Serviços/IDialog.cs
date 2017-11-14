using System.Windows;

namespace Unisc.Massas.Core.Servicos
{
    public interface IDialog
    {
        void Close();
        object DataContext { get; set; }
        bool? DialogResult { get; set; }
        Window Owner { get; set; }
        bool? ShowDialog();
    }
}
