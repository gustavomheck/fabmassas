using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Unisc.Massas.Client.Views;
using Unisc.Massas.Core;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaViewModelBase<TEntity> : ViewModelBase where TEntity : EntityBase
    {
        private readonly IRepositorio<TEntity> repositorio;
        private ICollectionView _collectionView;
        private TEntity _entidadeAux;
        private TEntity _entidadeSelecionada;
        private KeyValuePair<string, string> _colunaSelecionada;
        private IDictionary<string, string> _colunasFiltro;
        private string _filtro;

        public ConsultaViewModelBase(string viewName)
        {
            ViewName = viewName;
        }

        public ConsultaViewModelBase(IRepositorio<TEntity> repositorio, string viewName)
        {
            this.repositorio = repositorio;
            ViewName = viewName;

            _entidadeAux = Activator.CreateInstance<TEntity>();

            CarregarCommand = new DelegateCommand(Carregar);
            EditarCommand = new DelegateCommand(Editar);
            ExcluirCommand = new DelegateCommand(ExcluirAsync).ObservesCanExecute((p) => EntidadeSelecionadaHasValue);
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
        /// Obtém se a entidade selecionada possui valor.
        /// </summary>
        public bool EntidadeSelecionadaHasValue
        {
            get => EntidadeSelecionada != null;
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyValuePair<string, string> ColunaSelecionada
        {
            get => _colunaSelecionada;
            set => SetValue(ref _colunaSelecionada, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> ColunasFiltro
        {
            get => _colunasFiltro;
            set => SetValue(ref _colunasFiltro, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Filtro
        {
            get => _filtro;
            set
            {
                CollectionView = CollectionViewSource.GetDefaultView(Entidades);
                CollectionView.Filter = new Predicate<object>(o => _entidadeAux.Filtrar(o, ColunaSelecionada.Key, value));

                SetValue(ref _filtro, value);
            }
        }

        /// <summary>
        /// Obtém ou define o índice selecionado no DataGrid.
        /// </summary>
        public int IndiceSelecionado { get; set; }
        
        public ICommand EditarCommand { get; set; }
        public ICommand ExcluirCommand { get; set; }

        /// <summary>
        /// Carrega as entidades do banco.
        /// </summary>
        protected void Carregar()
        {
            ApplicationHelper.ExecuteAction(new Action(
                async () =>
                {
                    ColunasFiltro = _entidadeAux.GetColunasFiltro();
                    ColunaSelecionada = ColunasFiltro.FirstOrDefault();
                    var cvs = new CollectionViewSource()
                    {
                        Source = Entidades = await repositorio.GetAllAsNoTrackingAsync()
                    };

                    CollectionView = cvs.View;
                }));
        }

        /// <summary>
        /// Editar uma entidade.
        /// </summary>
        protected virtual void Editar()
        {
            // Método deve ser sobreescrito pelas classes filhas.
        }

        /// <summary>
        /// Editar uma entidade.
        /// </summary>
        public virtual async void EditarAsync(UserControl view)
        {
            object result = await DialogHost.Show(view, "RootDialog");
            TEntity entidade = ((EdicaoViewModelBase<TEntity>)view.DataContext).EntidadeSelecionada;

            if (result is bool?)
            {
                var r = result as bool?;                

                if (r.HasValue)
                {
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
                repositorio.Detach(entidade);
                bool excluir = await ExcluirInternoAsync();
                
                if (!excluir)
                    EditarAsync(view);
            }
            else if (result == null)
            {
                repositorio.Rollback(entidade);
            }
        }

        /// <summary>
        /// Excluir uma entidade.
        /// </summary>
        protected virtual async void ExcluirAsync()
        {
            await ExcluirInternoAsync();
        }

        private async Task<bool> ExcluirInternoAsync()
        {
            if (EntidadeSelecionada.PodeExcluir(out string motivo))
            {
                var view = new DialogView()
                {
                    DataContext = new DialogViewModel("Deseja remover o registro selecionado?", DialogResult.YesNo)
                };
                var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

                if (result.HasValue && result.Value)
                {
                    int indice = IndiceSelecionado;

                    if (repositorio.Delete(EntidadeSelecionada, out var errorMessage))
                    {
                        Entidades.RemoveAt(indice);
                        return true;
                    }
                }
            }
            else
            {
                var view = new DialogView()
                {
                    DataContext = new DialogViewModel(motivo, DialogResult.OK)
                };
                await DialogHost.Show(view, "RootDialog");
            }

            return false;
        }
    }
}
