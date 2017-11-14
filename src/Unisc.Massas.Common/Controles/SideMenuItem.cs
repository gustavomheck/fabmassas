using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Unisc.Massas.Core.Controles
{
    public class SideMenuItem : TreeViewItem
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                "Icon",
                typeof(string),
                typeof(SideMenuItem),
                new PropertyMetadata(String.Empty));

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetCurrentValue(IconProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            MouseLeftButtonUp += OnMouseLeftButtonUp;
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsExpanded = !IsExpanded;
            e.Handled = true;
        }
    }
}
