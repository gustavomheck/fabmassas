using System;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroViewModelBase<TEntity> : ViewModelBase where TEntity : EntityBase
    {
        private readonly IRepositorio<TEntity> repositorio;
        protected TEntity _entidadeSelecionada;

        public CadastroViewModelBase(IRepositorio<TEntity> repositorio, string viewName)
        {
            this.repositorio = repositorio;
            ViewName = viewName;

            CarregarCommand = new DelegateCommand(Carregar);
            LimparCommand = new DelegateCommand(Limpar);
            SalvarCommand = new DelegateCommand(Salvar);

            Limpar();
        }

        /// <summary>
        /// Obtém ou define a entidade selecionada.
        /// </summary>
        public virtual TEntity EntidadeSelecionada
        {
            get => _entidadeSelecionada;
            set => SetValue(ref _entidadeSelecionada, value);
        }

        public ICommand LimparCommand { get; set; }
        public ICommand SalvarCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Carregar()
        {
            // Override
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Limpar()
        {
            EntidadeSelecionada = Activator.CreateInstance<TEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Salvar()
        {
            string errorMsg;
            bool result;

            if (EntidadeSelecionada.Id == 0)
            {
                result = repositorio.Insert(EntidadeSelecionada, out errorMsg);
            }
            else
            {
                result = repositorio.Update(EntidadeSelecionada, out errorMsg);
            }

            if (!result)
            {
                var view = new DialogView()
                {
                    DataContext = new DialogViewModel("O registro não pôde ser salvo", DialogResult.OK)
                };
            }
            else
            {
                Limpar();
            }
        }
    }
}
