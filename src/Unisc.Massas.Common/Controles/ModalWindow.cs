using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shell;

namespace Unisc.Massas.Core.Controles
{
    public class ModalWindow : Window
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Owner == null)
                throw new InvalidOperationException("A propriedade Owner não pode ser nula quando a janela for modal.");

            //BorderBrush = new BrushConverter().ConvertFromString("#262626") as SolidColorBrush;
            //BorderThickness = new Thickness(1);
            ShowInTaskbar = false;
            SnapsToDevicePixels = true;
            Owner.Opacity = 0.7;            
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WindowStyle = WindowStyle.None;

            WindowChrome.SetWindowChrome(this, new WindowChrome()
            {
                CaptionHeight = 0,
                ResizeBorderThickness = new Thickness(0)
            });

            Closing += (s, e) => Owner.Opacity = 1;
        }
    }
}
