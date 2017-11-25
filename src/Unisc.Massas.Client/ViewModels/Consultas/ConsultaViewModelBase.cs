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
        private TEntity _entidadeAux;
        private string _filtro;
        private string _viewNameConsulta;
        private string _viewNameCadastro;

        public ConsultaViewModelBase(string viewName)
        {
            ViewName = viewName;
        }

        public ConsultaViewModelBase(IRepositorio<TEntity> repositorio, string viewNameConsulta, string viewNameCadastro)
        {
            this.repositorio = repositorio;
            ViewName = _viewNameConsulta = viewNameConsulta;
            _viewNameCadastro = viewNameCadastro;

            _entidadeAux = Activator.CreateInstance<TEntity>();

            CarregarCommand = new DelegateCommand(Carregar);
            EditarCommand = new DelegateCommand(Editar);
            ExcluirCommand = new DelegateCommand(ExcluirAsync);
            SalvarCommand = new DelegateCommand(Salvar);
            VoltarCommand = new DelegateCommand(Voltar);
        }
        
        public ObservableCollection<TEntity> Entidades { get; set; }
        public ICollectionView CollectionView { get; set; }
        public TEntity EntidadeSelecionada { get; set; }        
        public bool EntidadeSelecionadaHasValue => EntidadeSelecionada != null;
        public KeyValuePair<string, string> ColunaSelecionada { get; set; }
        public IDictionary<string, string> ColunasFiltro { get; set; }
        public int TabIndex { get; set; }
        public int IndiceSelecionado { get; set; }

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

        public ICommand EditarCommand { get; set; }
        public ICommand ExcluirCommand { get; set; }
        public ICommand SalvarCommand { get; set; }
        public ICommand VoltarCommand { get; set; }

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
            TabIndex = 1;
            ViewName = _viewNameCadastro;
        }

        /// <summary>
        /// Editar uma entidade.
        /// </summary>
        [Obsolete("Sobreescrever o método Editar")]
        public virtual async void EditarAsync(UserControl view)
        {
            object result = await DialogHost.Show(view, "RootDialog");
            TEntity entidade = default(TEntity);

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
                    DataContext = new DialogViewModel("Tem certeza que deseja excluir este registro?", "Excluir registro", DialogResult.CancelDelete)
                };
                var result = (bool?)(await DialogHost.Show(view, "RootDialog"));

                if (result.HasValue && result.Value)
                {
                    int indice = IndiceSelecionado;

                    if (repositorio.Delete(EntidadeSelecionada, out var errorMessage))
                    {
                        Entidades.RemoveAt(indice);
                        TabIndex = 0;
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

        protected virtual void Salvar()
        {
            // Override
        }

        protected void Salvar(TEntity entidade)
        {
            string errorMsg;
            bool result;

            if (!entidade.IsValid)
            {
                var view = new DialogView()
                {
                    DataContext = new DialogViewModel("Dados incorretos", DialogResult.OK)
                };

                DialogHost.Show(view, "RootDialog");
                return;
            }

            if (entidade.Id == 0)
            {
                result = repositorio.Insert(entidade, out errorMsg);
            }
            else
            {
                result = repositorio.Update(entidade, out errorMsg);
            }

            if (!result)
            {
                var view = new DialogView()
                {
                    DataContext = new DialogViewModel("O registro não pôde ser salvo", DialogResult.OK)
                };

                DialogHost.Show(view, "RootDialog");
            }
            else
            {
                int indice = IndiceSelecionado;
                Entidades.RemoveAt(indice);
                Entidades.Insert(indice, entidade);
                Voltar();
            }
        }

        private void Voltar()
        {
            TabIndex = 0;
            ViewName = _viewNameConsulta;
        }
    }
}
