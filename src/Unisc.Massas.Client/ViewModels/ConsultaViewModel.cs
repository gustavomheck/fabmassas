using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaViewModel : ViewModelBase
    {
    }

    public class ConsultaViewModel<TEntity> : ConsultaViewModel where TEntity : class, IEntity
    {
        private readonly IRepositorio<TEntity> repositorio;
        private TEntity _entidadeAux;
        private TEntity _entidadeSelecionada;
        private ICollectionView _collectionView;
        private string _filtro;

        /// <summary>
        /// Inicializa uma nova instância da classe ConsultaViewModel.
        /// </summary>
        /// <param name="repositorio">O repositório que conversa com o banco de dados.</param>
        public ConsultaViewModel(IRepositorio<TEntity> repositorio)
        {
            this.repositorio = repositorio;

            CadastrarCommand = new DelegateCommand(CadastrarAsync);
            CarregarCommand = new DelegateCommand(Carregar);
            EditarCommand = new DelegateCommand<UserControl>(EditarAsync).ObservesCanExecute((p) => EntidadeSelecionadaHasValue);
            ExcluirCommand = new DelegateCommand(ExcluirAsync).ObservesCanExecute((p) => EntidadeSelecionadaHasValue);

            _entidadeAux = Activator.CreateInstance<TEntity>();
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
                OnPropertyChanged(nameof(EntidadeSelecionadaHasValue));
            }
        }

        /// <summary>
        /// Obtém ou define todas as entidades do banco.
        /// </summary>
        public ObservableCollection<TEntity> Entidades { get; set; }

        public ICollectionView CollectionView
        {
            get => _collectionView;
            set => SetValue(ref _collectionView, value);
        }

        public string Filtro
        {
            get => _filtro;
            set
            {
                CollectionView = CollectionViewSource.GetDefaultView(Entidades);
                CollectionView.Filter = new Predicate<object>(o => _entidadeAux.Filtrar(o, "", value));

                SetValue(ref _filtro, value);
            }
        }

        /// <summary>
        /// Obtém se a entidade selecionada possui valor.
        /// </summary>
        public bool EntidadeSelecionadaHasValue
        {
            get => EntidadeSelecionada != null;
        }

        /// <summary>
        /// Obtém ou define o índice selecionado no DataGrid.
        /// </summary>
        public int IndiceSelecionado { get; set; }

        public ICommand CadastrarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand ExcluirCommand { get; private set; }
        
        /// <summary>
        /// Cadastra uma nova entidade.
        /// </summary>
        public virtual async void CadastrarAsync()
        {
            var view = new CadastroEmpresaView()
            {
                DataContext = DependencyFactory.Resolve<CadastroViewModel, TEntity>()
            };

            var result = (bool?)(await DialogHost.Show(view));

            if (result.HasValue && result.Value)
                Entidades.Add(((CadastroViewModel<TEntity>)view.DataContext).EntidadeSelecionada);
        }

        /// <summary>
        /// Carrega as entidades do banco.
        /// </summary>
        private void Carregar()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(
                async () =>
                {
                    var cvs = new CollectionViewSource()
                    {
                        Source = Entidades = await repositorio.GetAllAsNoTrackingAsync()
                    };
                    
                    CollectionView = cvs.View;
                }), DispatcherPriority.Background);
        }

        /// <summary>
        /// Editar uma entidade.
        /// </summary>
        public virtual async void EditarAsync(UserControl view)
        {
            if (view == null)
            {
                view = new CadastroEmpresaView()
                {
                    DataContext = new CadastroViewModel<TEntity>(/*repositorio.GetById(EntidadeSelecionada.Id)*/EntidadeSelecionada)
                };
            }            

            object result = await DialogHost.Show(view);

            if (result is bool?)
            {
                var r = result as bool?;

                if (r.HasValue)
                {
                    TEntity entidade = ((CadastroViewModel<TEntity>)view.DataContext).EntidadeSelecionada;
                    int indice = IndiceSelecionado;

                    Entidades.RemoveAt(indice);

                    if (r.Value)
                    {
                        repositorio.Update(entidade, out var errorMessage);
                        Entidades.Insert(indice, entidade);
                    }
                    else
                    {
                        repositorio.Delete(entidade, out var errorMessage);
                    }
                }
            }
            else if (result is string && ((string)result) == "Excluir")
            {
                bool excluir = await ExcluirInternoAsync();

                if (!excluir)
                    EditarAsync(view);
                else
                {
                    TEntity entidade = ((CadastroViewModel<TEntity>)view.DataContext).EntidadeSelecionada;
                    int indice = IndiceSelecionado;

                    Entidades.RemoveAt(indice);
                    repositorio.Delete(entidade, out var errorMessage);
                }
            }
        }

        /// <summary>
        /// Excluir uma entidade.
        /// </summary>
        public virtual async void ExcluirAsync()
        {
            await ExcluirInternoAsync();
        }

        private async Task<bool> ExcluirInternoAsync()
        {
            var result = (bool?)(await DialogHost.Show(new DialogView()));

            if (result.HasValue && result.Value)
            {
                int indice = IndiceSelecionado;

                if (repositorio.Delete(EntidadeSelecionada, out var errorMessage))
                {
                    Entidades.RemoveAt(indice);
                    return true;
                }
            }

            return false;
        }
    }
}
