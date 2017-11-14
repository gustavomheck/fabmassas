using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeBrasil.Massas.Core.Interface
{
    public class EnterKeyTraversal
    {
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool),
            typeof(EnterKeyTraversal), new UIPropertyMetadata(false, IsEnabledChanged));

        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        static void ue_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var ue = e.OriginalSource as FrameworkElement;

            if (e.Key != Key.Enter) return;
            if (ue == null) return;
            if (ue.GetType() == typeof(Button)) return;
            if (ue.GetType() == typeof(CheckBox)) return;

            e.Handled = true;

            ue.MoveFocus((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift ?
                new TraversalRequest(FocusNavigationDirection.Previous) :
                new TraversalRequest(FocusNavigationDirection.Next));
        }

        static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ue = d as FrameworkElement;
            if (ue == null) return;

            if ((bool)e.NewValue)
            {
                ue.Unloaded += ue_Unloaded;
                ue.PreviewKeyDown += ue_PreviewKeyDown;
            }
            else
            {
                ue.PreviewKeyDown -= ue_PreviewKeyDown;
            }
        }

        private static void ue_Unloaded(object sender, RoutedEventArgs e)
        {
            var ue = sender as FrameworkElement;

            if (ue == null) return;

            ue.Unloaded -= ue_Unloaded;
            ue.PreviewKeyDown -= ue_PreviewKeyDown;
        }
    }
}
