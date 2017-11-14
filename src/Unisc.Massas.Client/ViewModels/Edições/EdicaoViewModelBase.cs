using System.Windows.Input;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class EdicaoViewModelBase<TEntity> : ViewModelBase where TEntity : EntityBase
    {
        private TEntity _entidadeSelecionada;
        
        public EdicaoViewModelBase(TEntity entidade, string viewName)
        {
            EntidadeSelecionada = entidade;
            ViewName = viewName;

            CarregarCommand = new DelegateCommand(Carregar);
        }

        /// <summary>
        /// Obtém ou define a entidade selecionada.
        /// </summary>
        public TEntity EntidadeSelecionada
        {
            get => _entidadeSelecionada;
            set
            {
                SetValue(ref _entidadeSelecionada, value);
            }
        }

        public ICommand SalvarCommand { get; set; }
        public ICommand ExcluirCommand { get; set; }
        public ICommand LimparCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Carregar()
        {
            // Override
        }
    }
}
