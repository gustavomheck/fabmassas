using System;

namespace Unisc.Massas.Client.ViewModels
{
    public enum DialogResult
    {
        OK,
        YesNo,
    }

    public enum DialogType
    {
        Caption,
        CaptionText
    }
    
    public class DialogViewModel : ViewModelBase
    {
        private string _titulo;
        private string _texto;
        private DialogResult _dialogResult;
        private DialogType _dialogType;

        public DialogViewModel(string titulo, DialogResult dialogResult) : this("", titulo, dialogResult)
        {
        }

        public DialogViewModel(string texto, string titulo, DialogResult dialogResult)
        {
            Texto = texto;
            Titulo = titulo;
            DialogResult = dialogResult;
            DialogType = String.IsNullOrEmpty(Texto) ? DialogType.Caption : DialogType.CaptionText;
        }

        public string Titulo
        {
            get => _titulo;
            set => SetValue(ref _titulo, value);
        }

        public string Texto
        {
            get => _texto;
            set => SetValue(ref _texto, value);
        }

        public DialogResult DialogResult
        {
            get => _dialogResult;
            set => SetValue(ref _dialogResult, value);
        }

        public DialogType DialogType
        {
            get => _dialogType;
            set => SetValue(ref _dialogType, value);
        }
    }
}
