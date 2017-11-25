using System;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ModalViewModelBase<TEntity> : ViewModelBase where TEntity : EntityBase
    {
        public ModalViewModelBase()
        {
            EntidadeSelecionada = Activator.CreateInstance<TEntity>();
        }

        public TEntity EntidadeSelecionada { get; set; }
    }
}
