using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.String;

namespace Unisc.Massas.Core.Controles
{
    public class NumericTextBox : TextBox
    {
        #region Variables 

        private ImageButton _clearButton;

        #endregion // Variables

        #region Dependency Properties
        
        public static readonly DependencyProperty InputTypeProperty =
            DependencyProperty.Register("InputType",
                typeof(InputType),
                typeof(NumericTextBox),
                new FrameworkPropertyMetadata(InputType.Integer));

        #endregion // Dependency Properties
        
        #region Properties
        
        /// <summary>
        /// Obtém ou define o tipo de TextBox.
        /// </summary>
        [Description("Obtém ou define o tipo de entrada da TextBox.")]
        public InputType InputType
        {
            get { return (InputType)GetValue(InputTypeProperty); }
            set { SetValue(InputTypeProperty, value); }
        }

        #endregion // Properties

        #region Métodos

        /// <summary>
        /// Ocorre quando o modelo de um controle é aplicado.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _clearButton = Template.FindName("ClearButton", this) as ImageButton;

            if (_clearButton != null)
                _clearButton.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(ClearButton_PreviewMouseLeftButtonDown);

            switch (InputType)
            {
                case InputType.Decimal:
                    LostFocus += new RoutedEventHandler(Decimal_OnLostFocus);
                    PreviewTextInput += Decimal_OnPreviewTextInput;
                    AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(Decimal_PastingEvent));
                    break;
                case InputType.Integer:
                    PreviewTextInput += new TextCompositionEventHandler(Integer_OnPreviewTextInput);
                    TextChanged += new TextChangedEventHandler(Integer_OnTextChanged);

                    AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(Integer_PastingEvent));
                    break;
            }
        }

        private bool CanAddComa(object sender, string proximo)
        {
            var textBox = sender as TextBox;

            if (textBox == null)
                return true;

            if (IsNullOrWhiteSpace(textBox.Text) && proximo.Equals(","))
                return false;

            if (Char.IsNumber(proximo.ToCharArray()[0]))
                return true;

            if (proximo.Equals(","))
                return !textBox.Text.Any(x => x.Equals(','));

            return true;
        }

        /// <summary>
        /// Verifica a semântica da pontuação.
        /// </summary>
        /// <param name="sender">O System.Windows.Controls.TextBox que disparou o evento.</param>
        /// <param name="text">O texto da TextBox</param>
        /// <returns>Verdadeiro se o texto inserido é válido.</returns>
        private bool Decimal_IsEntryDisallowed(object sender, string text)
        {
            var regex = new Regex(@"^[0-9]|\,$");

            if (regex.IsMatch(text))
            {
                return !CanAddComa(sender, text);
            }

            return true;
        }

        /// <summary>
        /// Verifica se o texto é composto de números.
        /// </summary>
        /// <param name="text">O texto a ser verificado.</param>
        /// <returns>Falso se o texto é composto de números.</returns>
        private bool Decimal_IsTextDisallowed(string text)
        {
            var r = new Regex(@"^((\d+)|(\d{1,3}(\.\d{3})+)|(\d{1,3}(\.\d{3})(\,\d{3})+))((\,\d{6})|(\,\d{5})|(\,\d{4})|(\,\d{3})|(\,\d{2})|(\,\d{1})|(\,))?$");
            return !r.IsMatch(text);
        }

        /// <summary>
        /// Verifica se o texto é composto por um número inteiro.
        /// </summary>
        /// <param name="text">O texto a ser verificado.</param>
        /// <returns>Falso se o texto inserido não for um número inteiro.</returns>
        private bool Integer_IsTextDisallowed(string text)
        {
            var regexHex = new Regex(@"(^[0-9]+$|^$)");
            return !regexHex.IsMatch(text);
        }

        #endregion // Métodos

        #region Eventos
        
        private void ClearButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SetValue(TextProperty, Empty);
        }

        private void Decimal_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNullOrEmpty(e.Text))
            {
                e.Handled = true;
            }
            else if (Decimal_IsEntryDisallowed(sender, e.Text))
            {
                e.Handled = true;
            }
        }

        private void Decimal_PastingEvent(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));

                if (Decimal_IsTextDisallowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void Decimal_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsNullOrWhiteSpace(Text))
            {
                Text = Format("{0:0.00}", Convert.ToDouble(Text, CultureInfo.CurrentCulture));
            }
        }

        private void Integer_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (textBox == null) return;
            
            if (Integer_IsTextDisallowed(textBox.Text)) return;

            Text = textBox.Text;
        }

        private void Integer_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNullOrEmpty(e.Text))
            {
                e.Handled = true;
            }
            else if (Integer_IsTextDisallowed(e.Text))
            {
                e.Handled = true;
            }
        }

        private void Integer_PastingEvent(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));

                if (Integer_IsTextDisallowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        #endregion // Eventos
    }

    public enum InputType
    {
        Decimal = 0,
        Integer = 1
    }
}
