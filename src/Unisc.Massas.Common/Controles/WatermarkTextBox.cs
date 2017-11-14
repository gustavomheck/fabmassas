using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Unisc.Massas.Core.Controles
{
    public class WatermarkTextBox : TextBox
    {
        private ImageButton _clearButton;

        public static readonly DependencyProperty ClearButtonVisibilityProperty =
            DependencyProperty.Register(
                "ClearButtonVisibility",
                typeof(Visibility),
                typeof(WatermarkTextBox),
                new FrameworkPropertyMetadata(Visibility.Collapsed));

        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.Register(
                "HasText",
                typeof(bool),
                typeof(WatermarkTextBox),
                new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder",
                typeof(string),
                typeof(WatermarkTextBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty PlaceholderVisibilityProperty =
            DependencyProperty.Register(
                "PlaceholderVisibility",
                typeof(Visibility),
                typeof(WatermarkTextBox),
                new FrameworkPropertyMetadata(Visibility.Visible));

        static WatermarkTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WatermarkTextBox),
                new FrameworkPropertyMetadata(typeof(WatermarkTextBox)));
        }

        /// <summary>
        /// Obtém ou define a visibilidade do botão para limpar o texto da TextsBox.
        /// </summary>
        [Description("Obtém ou define a visibilidade do botão para limpar o texto da TextBox.")]
        public Visibility ClearButtonVisibility
        {
            get { return (Visibility)GetValue(ClearButtonVisibilityProperty); }
            set { SetValue(ClearButtonVisibilityProperty, value); }
        }

        /// <summary>
        /// Obtém ou define um valor do tipo System.Boolean indicando se a TextBox tem ou não texto.
        /// </summary>
        [Description("Obtém ou define um valor do tipo System.Boolean indicando se a TextBox tem ou não texto.")]
        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            set
            {
                SetValue(HasTextProperty, value);

                if (value)
                {
                    SetValue(ClearButtonVisibilityProperty, Visibility.Visible);
                    SetValue(PlaceholderVisibilityProperty, Visibility.Collapsed);                    
                }
                else
                {
                    SetValue(ClearButtonVisibilityProperty, Visibility.Collapsed);
                    SetValue(PlaceholderVisibilityProperty, Visibility.Visible);
                }
            }
        }

        /// <summary>
        /// Obtém ou define o texto para a marca d'água.
        /// </summary>
        [Description("Obtém ou define o texto para a marca d'água.")]
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        /// <summary>
        /// Obtém ou define a visibilidade da marca d'água
        /// </summary>
        [Description("Obtém ou define a visibilidade da marca d'água.")]
        public Visibility PlaceholderVisibility
        {
            get { return (Visibility)GetValue(PlaceholderVisibilityProperty); }
            set { SetValue(PlaceholderVisibilityProperty, value); }
        }

        /// <summary>
        /// Ocorre quando o modelo de um controle é aplicado.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            _clearButton = Template.FindName("ClearButton", this) as ImageButton;

            if (_clearButton != null)
                _clearButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ClearButton_PreviewMouseLeftButtonDown);
        }

        /// <summary>
        /// Invoked when TextBox control raises TextChanged event.
        /// </summary>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            HasText = !String.IsNullOrEmpty(Text);
        }

        private void ClearButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Text = String.Empty;
        }
    }
}
