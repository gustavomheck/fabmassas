using System;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ModalViewModelBase<TEntity> : ViewModelBase where TEntity : EntityBase
    {
        public ModalViewModelBase() : this(null)
        {
        }

        public ModalViewModelBase(TEntity obj)
        {
            if (obj == null)
            {
                EntidadeSelecionada = Activator.CreateInstance<TEntity>();
                IsEditing = false;
            }
            else
            {
                EntidadeSelecionada = obj;
                IsEditing = true;
            }
        }

        public TEntity EntidadeSelecionada { get; set; }
        public bool IsEditing { get; set; }
    }
}
