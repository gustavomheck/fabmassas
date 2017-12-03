using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Unisc.Massas.Core.Controles
{
    /// <summary>
    /// Uma TextBox que pode ter uma máscara para o texto.
    /// </summary>
    [Description("Uma TextBox que pode ter uma máscara para o texto.")]
    public class MaskedTextBox : TextBox
    {
        #region Variáveis

        public static readonly DependencyProperty CasingProperty =
            DependencyProperty.Register(
                "Casing",
                typeof(CharacterCasing),
                typeof(MaskedTextBox),
                new PropertyMetadata(CharacterCasing.Normal));

        public static readonly DependencyProperty InputMaskProperty =
           DependencyProperty.Register(
               "InputMask",
               typeof(string),
               typeof(MaskedTextBox),
               new PropertyMetadata("_"));

        public static readonly DependencyProperty PromptCharProperty =
            DependencyProperty.Register(
                "PromptChar",
                typeof(char),
                typeof(MaskedTextBox),
                new PropertyMetadata('_'));

        public static DependencyProperty UnmaskedTextProperty =
            DependencyProperty.Register(
                "UnmaskedText",
                typeof(string),
                typeof(MaskedTextBox),
                new FrameworkPropertyMetadata("", OnMaskedChangedCallback)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

        #endregion // Variáveis

        #region Propriedades

        /// <summary>
        /// Obtém ou define se os caracteres devem ser normais, minúsculos ou maiúculos.
        /// </summary>
        [Description("Obtém ou define se os caracteres devem ser normais, minúsculos ou maiúculos.")]
        public CharacterCasing Casing
        {
            get { return (CharacterCasing)GetValue(CasingProperty); }
            set { SetValue(CasingProperty, value); }
        }

        /// <summary>
        /// Obtém ou define a máscara da TextBox.
        /// </summary>
        [Description("A máscara da TextBox.")]
        public string InputMask
        {
            get { return (string)GetValue(InputMaskProperty); }
            set { SetValue(InputMaskProperty, value); }
        }

        /// <summary>
        /// Obtém ou define o caractere da máscara.
        /// </summary>
        [Description("O caractere da máscara.")]
        public char PromptChar
        {
            get { return (char)GetValue(PromptCharProperty); }
            set { SetValue(PromptCharProperty, value); }
        }

        /// <summary>
        /// Obtém ou define o texto sem máscara da TextBox.
        /// </summary>
        [Description("O texto sem máscara da TextBox.")]
        public string UnmaskedText
        {
            get { return (string)GetValue(UnmaskedTextProperty); }
            set { SetValue(UnmaskedTextProperty, value); }
        }

        #endregion

        private MaskedTextProvider _provider;
        private ImageButton _clearButton;

        static MaskedTextBox()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(
            //    typeof(MaskedTextBox),
            //    new FrameworkPropertyMetadata(typeof(MaskedTextBox)));
        }

        private static void OnMaskedChangedCallback(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ((MaskedTextBox)source).UnmaskedText = (string)e.NewValue;
            ((MaskedTextBox)source).Text = (string)e.NewValue;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Loaded += OnLoaded;
            PreviewTextInput += OnPreviewTextInput;
            PreviewKeyDown += OnPreviewKeyDown;
            TextChanged += OnTextChanged;
            PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;

            _clearButton = (ImageButton)Template.FindName("ClearButton", this);

            if (_clearButton != null)
                _clearButton.PreviewMouseLeftButtonDown += ClearButton_PreviewMouseLeftButtonDown;

            _provider = new MaskedTextProvider(InputMask, CultureInfo.InvariantCulture);

            _provider.Set(String.IsNullOrWhiteSpace(UnmaskedText) ? String.Empty : UnmaskedText);

            _provider.PromptChar = PromptChar;
            Text = _provider.ToDisplayString();

            var textProp = DependencyPropertyDescriptor.FromProperty(TextProperty, typeof(MaskedTextBox));

            if (textProp != null)
            {
                textProp.AddValueChanged(this, (s, args) => UpdateText());
            }

            DataObject.AddPastingHandler(this, Pasting);

            var dpd = DependencyPropertyDescriptor.FromProperty(InputMaskProperty, typeof(MaskedTextBox));

            if (dpd != null)
            {
                dpd.AddValueChanged(this, delegate
                {
                    _provider = new MaskedTextProvider(InputMask, CultureInfo.InvariantCulture);
                    _provider.Set(String.IsNullOrWhiteSpace(UnmaskedText) ? String.Empty : UnmaskedText);

                    _provider.PromptChar = PromptChar;
                    Text = _provider.ToDisplayString();
                });
            }
        }

        #region Eventos

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            _provider = new MaskedTextProvider(InputMask, CultureInfo.InvariantCulture);

            _provider.Set(String.IsNullOrWhiteSpace(UnmaskedText) ? String.Empty : UnmaskedText);

            _provider.PromptChar = PromptChar;
            Text = _provider.ToDisplayString();

            var textProp = DependencyPropertyDescriptor.FromProperty(TextProperty, typeof(MaskedTextBox));

            if (textProp != null)
            {
                textProp.AddValueChanged(this, (s, args) => UpdateText());
            }

            DataObject.AddPastingHandler(this, Pasting);

            #region Evento do InputMask

            var dpd = DependencyPropertyDescriptor.FromProperty(InputMaskProperty, typeof(MaskedTextBox));

            if (dpd != null)
            {
                dpd.AddValueChanged(this, delegate
                {
                    _provider = new MaskedTextProvider(InputMask, CultureInfo.InvariantCulture);
                    _provider.Set(String.IsNullOrWhiteSpace(UnmaskedText) ? String.Empty : UnmaskedText);

                    _provider.PromptChar = PromptChar;
                    Text = _provider.ToDisplayString();
                });
            }

            #endregion
        }

        private void ClearButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            _provider.Clear();
            RefreshText(0);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged -= OnTextChanged;

            TreatSelectedText();

            _provider.Clear();

            if (Text != null)
                foreach (var letra in Text.ToArray())
                {
                    _provider.Add(letra);
                }

            RefreshText(0);

            e.Handled = true;

            TextChanged += OnTextChanged;
        }

        void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                TreatSelectedText();

                var position = GetNextCharacterPosition(SelectionStart, true);

                if (_provider.InsertAt(" ", position))
                    RefreshText(position);

                e.Handled = true;
            }

            if (e.Key == Key.Back)
            {
                if (TreatSelectedText())
                {
                    RefreshText(SelectionStart);
                }
                else
                {
                    if (SelectionStart != 0)
                    {
                        if (_provider.RemoveAt(SelectionStart - 1))
                            RefreshText(SelectionStart - 1);
                    }
                }

                e.Handled = true;
            }

            if (e.Key == Key.Delete)
            {
                if (TreatSelectedText())
                {
                    RefreshText(SelectionStart);
                }
                else
                {
                    if (_provider.RemoveAt(SelectionStart))
                        RefreshText(SelectionStart);
                }

                e.Handled = true;
            }
        }

        void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TreatSelectedText();

            var position = GetNextCharacterPosition(SelectionStart, true);

            if (Keyboard.IsKeyToggled(Key.Insert))
            {
                if (_provider.Replace(e.Text, position))
                    position++;
            }
            else
            {
                if (_provider.InsertAt(e.Text, position))
                    position++;
            }

            position = GetNextCharacterPosition(position, true);

            RefreshText(position);

            e.Handled = true;
        }

        private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var tb = sender as MaskedTextBox;

            if (tb == null)
                return;

            tb.SelectionLength = 0;

            if (String.IsNullOrEmpty(UnmaskedText))
            {
                tb.SelectionStart = 0;
                return;
            }

            var maskProvider = new MaskedTextProvider(InputMask, CultureInfo.InvariantCulture);
            int totalCont = 0;
            int cont = 0;

            foreach (char letra in maskProvider.ToDisplayString())
            {
                totalCont++;

                if (letra.Equals(PromptChar))
                    cont++;

                if (cont == UnmaskedText.Length)
                    break;
            }

            var maskCut = maskProvider.ToDisplayString().Substring(0, totalCont);
            maskCut = maskCut.Replace(PromptChar.ToString(), "");
            tb.SelectionStart = UnmaskedText.Length + maskCut.Length;
        }

        #endregion // Eventos

        #region Métodos

        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));

                TreatSelectedText();

                var position = GetNextCharacterPosition(SelectionStart, true);

                if (_provider.InsertAt(pastedText, position))
                {
                    RefreshText(position);
                }
            }

            e.CancelCommand();
        }

        private void UpdateText()
        {
            if (_provider.ToDisplayString().Equals(Text))
                return;

            var success = _provider.Set(Text);

            SetText(success ? _provider.ToDisplayString() : Text, _provider.ToString(false, false));
        }

        private bool TreatSelectedText()
        {
            if (SelectionLength > 0)
            {
                return _provider.RemoveAt(SelectionStart, SelectionStart + SelectionLength - 1);
            }

            return false;
        }

        private void RefreshText(int position)
        {
            SetText(_provider.ToDisplayString(), _provider.ToString(false, false));
            SelectionStart = position;
        }

        private void SetText(string text, string unmaskedText)
        {
            if (Casing == CharacterCasing.Upper)
            {
                UnmaskedText = String.IsNullOrWhiteSpace(unmaskedText) ? String.Empty : unmaskedText.ToUpper();
                Text = String.IsNullOrWhiteSpace(text) ? String.Empty : text.ToUpper();
            }
            else
            {
                UnmaskedText = String.IsNullOrWhiteSpace(unmaskedText) ? String.Empty : unmaskedText;
                Text = String.IsNullOrWhiteSpace(text) ? String.Empty : text;
            }
        }

        private int GetNextCharacterPosition(int startPosition, bool goForward)
        {
            var position = _provider.FindEditPositionFrom(startPosition, goForward);

            if (position == -1)
                return startPosition;
            return position;
        }

        #endregion // Métodos
    }
}
