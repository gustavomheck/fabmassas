using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Unisc.Massas.Domain.Models
{
    public class EntityBase : IEntity, IDataErrorInfo, INotifyPropertyChanged
    {
        public int Id { get; set; }

        [NotMapped]
        public bool IsValid { get; private set; }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                IsValid = ValidarObjeto();
                OnPropertyChanged(nameof(IsValid));

                return ValidarPropriedade(propertyName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>();
        }

        public virtual bool Filtrar(object obj, string propertyName, string value)
        {
            return false;
        }

        protected virtual bool ValidarObjeto()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this), new Collection<ValidationResult>(), true);
        }

        protected virtual string ValidarPropriedade(string propertyName)
        {
            object propertyValue = GetType().GetProperty(propertyName).GetValue(this, null);
            var context = new ValidationContext(this) { MemberName = propertyName };
            var results = new Collection<ValidationResult>();
            bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

            if (!isValid)
            {
                ValidationResult result = results.SingleOrDefault();
                return result?.ErrorMessage;
            }

            return null;
        }

        public virtual bool PodeExcluir(out string motivo)
        {
            motivo = String.Empty;
            return true;
        }

        public virtual void ExcluirRelacionamentos()
        {
            // Sobrescrever nas entidades que precisam remover relacionamentos antes de serem deletadas.
        }
    }
}
