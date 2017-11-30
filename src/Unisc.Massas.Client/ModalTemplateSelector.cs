using System.Windows;
using System.Windows.Controls;

namespace Unisc.Massas.Client
{
    public class ModalTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var isEditing = item as bool?;
            string key = isEditing.HasValue && isEditing.Value ? "TemplateCancelarSalvar" : "TemplateCancelarAdicionar";
            return (DataTemplate)Application.Current.Resources[key]; 
        }
    }
}
