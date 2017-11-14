using System;
using System.Windows.Input;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroViewModel : ViewModelBase
    {
        public CadastroViewModel()
        {                
        }

        public CadastroViewModel(string viewName)
        {
            ViewName = viewName;
        }

        public ICommand CancelarCommand { get; set; }
    }

    public class CadastroViewModel<TEntity> : CadastroViewModel where TEntity : class, IEntity
    {
        private TEntity _entidadeSelecionada;

        public CadastroViewModel() : this(Activator.CreateInstance<TEntity>())
        {
        }

        public CadastroViewModel(TEntity entidade)
        {
            EntidadeSelecionada = entidade;
            CancelarCommand = new DelegateCommand(Cancelar);

            ViewName = entidade.Id == 0 ? "Cadastro de " + entidade.ToString() : "Alterar " + entidade.ToString();
        }

        public TEntity EntidadeSelecionada
        {
            get => _entidadeSelecionada;
            set
            {
                SetValue(ref _entidadeSelecionada, value);
                OnPropertyChanged(nameof(EstaEditando));
            }
        }

        public bool EstaEditando
        {
            get => EntidadeSelecionada?.Id > 0;
        }

        private void Cancelar()
        {
            int id = EntidadeSelecionada.Id;
            EntidadeSelecionada = Activator.CreateInstance<TEntity>();
            EntidadeSelecionada.Id = id;

            OnPropertyChanged(nameof(EstaEditando));
        }
    }
}
