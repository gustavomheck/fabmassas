using Microsoft.Practices.Unity;
using System;
using Unisc.Massas.Client.ViewModels;
using Unisc.Massas.Core.Servicos;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Data.Repositorios;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client
{
    /// <summary>
    /// Simple wrapper for unity resolution.
    /// </summary>
    public class DependencyFactory
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get => _container;
            set => _container = value;
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            var container = new UnityContainer();
            
            container.RegisterType<MainWindowViewModel>();
            container.RegisterType<IDialogService, DialogService>();
            container.RegisterType<IClienteRepositorio, ClienteRepositorio>();
            container.RegisterType<IEncomendaRepositorio, EncomendaRepositorio>();
            container.RegisterType<IEstadoRepositorio, EstadoRepositorio>();
            container.RegisterType<IEstoqueRepositorio, EstoqueRepositorio>();
            container.RegisterType<IFormaRepositorio, FormaRepositorio>();
            container.RegisterType<IFuncaoRepositorio, FuncaoRepositorio>();
            container.RegisterType<ILocalRepositorio, LocalRepositorio>();
            container.RegisterType<IMaquinaRepositorio, MaquinaRepositorio>();
            container.RegisterType<IPaisRepositorio, PaisRepositorio>();
            container.RegisterType<IPermissaoFuncaoRepositorio, PermissaoFuncaoRepositorio>();
            container.RegisterType<IProdutoRepositorio, ProdutoRepositorio>();
            container.RegisterType<ITelefoneRepositorio, TelefoneRepositorio>();
            container.RegisterType<ITipoMassaRepositorio, TipoMassaRepositorio>();
            container.RegisterType<IUnidadeMedidaRepositorio, UnidadeMedidaRepositorio>();
            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>();
            container.RegisterType<ICidadeRepositorio, CidadeRepositorio>();
            container.RegisterType<IEmpresaRepositorio, EmpresaRepositorio>();

            _container = container;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return.</typeparam>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <param name="type">The type to be resolved.</param>
        /// <returns>The resolved type as an object.</returns>
        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        //public static object Resolve<T1, T2>() where T1 : CadastroViewModel
        //                                       where T2 : class, IEntity
        //{
        //    return Container.Resolve(typeof(CadastroViewModel<>).MakeGenericType(typeof(T2)));
        //}
    }
}
