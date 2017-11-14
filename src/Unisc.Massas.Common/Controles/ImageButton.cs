using System;
using System.Windows;
using System.Windows.Controls;

namespace Unisc.Massas.Core.Controles
{
    public class ImageButton : Button
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                "Icon",
                typeof(string),
                typeof(ImageButton),
                new PropertyMetadata(String.Empty));

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetCurrentValue(IconProperty, value); }
        }
    }
}
