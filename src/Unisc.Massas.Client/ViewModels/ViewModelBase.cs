using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Unisc.Massas.Core.Servicos;

namespace Unisc.Massas.Client.ViewModels
{
    /// <summary>
    /// Uma classe abstrata que serve como base para os ViewModels.
    /// </summary>
    public abstract class ViewModelBase : IDataErrorInfo, IDialogRequestClose, INotifyPropertyChanged
    {
        private string _viewName;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        public string ViewName
        {
            get => _viewName;
            set => SetValue(ref _viewName, value);
        }

        string IDataErrorInfo.Error
        {
            get => null;
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get => ValidarPropriedade(propertyName);
        }

        public ICommand CarregarCommand { get; set; }
        public ICommand FecharCommand { get; set; }

        /// <summary>
        /// Valida uma propriedade do ViewModel.
        /// </summary>
        /// <param name="propertyName">O nome da propriedade a ser validada.</param>
        /// <returns>Verdadeiro se o valor da propriedade é válido; senão, falso.</returns>
        protected virtual string ValidarPropriedade(string propertyName)
        {
            object propertyValue = GetType().GetProperty(propertyName).GetValue(this, null);
            var context = new ValidationContext(this) { MemberName = propertyName };
            var results = new Collection<ValidationResult>();
            bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

            if (!isValid)
            {
                ValidationResult result = results.SingleOrDefault();
                return result == null ? null : result.ErrorMessage;
            }

            return null;
        }

        /// <summary>
        /// Atribui o valor à propriedade e dispara um evento de notificação
        /// se o valor foi mudado.
        /// </summary>
        /// <typeparam name="T">O tipo da propriedade</typeparam>
        /// <param name="storage">O campo da propriedade.</param>
        /// <param name="value">O novo valor.</param>
        /// <param name="propertyName">O nome da propriedade</param>
        /// <returns>Verdadeiro se o valor foi alterado; senão, falso.</returns>
        protected virtual bool SetValue<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Dispara o evento CloseRequested.
        /// <paramref name="dialogResult">O resultado do diálogo.</paramref>
        /// </summary>
        protected virtual void OnCloseRequested(bool? dialogResult)
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(dialogResult));
        }

        /// <summary>
        /// Dispara o evento PropertyChanged.
        /// </summary>
        /// <param name="propertyName">A propriedade alterada.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
