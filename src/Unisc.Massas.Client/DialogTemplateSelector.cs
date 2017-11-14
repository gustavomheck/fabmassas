using System.Windows;
using System.Windows.Controls;
using Unisc.Massas.Client.ViewModels;
using Unisc.Massas.Client.Views;

namespace Unisc.Massas.Client
{
    public class DialogTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var dialog = new DialogView();            

            if (item is DialogResult)
            {
                var dialogResult = (DialogResult)item;

                if (dialogResult == DialogResult.OK)
                {
                    return (DataTemplate)dialog.FindResource("DialogResultOK");
                }
                else if (dialogResult == DialogResult.YesNo)
                {
                    return (DataTemplate)dialog.FindResource("DialogResultYesNo");
                }
            }
            else if (item is DialogType)
            {
                var dialogType = (DialogType)item;

                if (dialogType == DialogType.Caption)
                {
                    return (DataTemplate)dialog.FindResource("DialogTypeCaption");
                }
                else if (dialogType == DialogType.CaptionText)
                {
                    return (DataTemplate)dialog.FindResource("DialogTypeCaptionText");
                }
            }

            return null;
        }
    }
}
