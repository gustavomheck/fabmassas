using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaUnidadesMedidaViewModel : ConsultaViewModelBase<UnidadeMedida>
    {
        private readonly IUnidadeMedidaRepositorio unidadeMedidaRepositorio;

        public ConsultaUnidadesMedidaViewModel(IUnidadeMedidaRepositorio unidadeMedidaRepositorio) 
            : base(unidadeMedidaRepositorio, "Consulta de Unidade de Medidad", "Edição de Unidade de Medida")
        {
            this.unidadeMedidaRepositorio = unidadeMedidaRepositorio;
        }
    }
}
