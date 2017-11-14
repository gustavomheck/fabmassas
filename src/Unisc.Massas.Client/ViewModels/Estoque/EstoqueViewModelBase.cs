using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class EstoqueViewModelBase : ViewModelBase
    {
        private readonly IRepositorio<Estoque> repositorio;

        public EstoqueViewModelBase(string viewName)
        {
            ViewName = viewName;
        }

        public EstoqueViewModelBase(IRepositorio<Estoque> repositorio, string viewName)
        {
            this.repositorio = repositorio;
            ViewName = viewName;
        }
    }
}
