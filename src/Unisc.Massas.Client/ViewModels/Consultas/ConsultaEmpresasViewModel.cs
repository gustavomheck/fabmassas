using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaEmpresasViewModel : ConsultaViewModelBase<Empresa>
    {
        public ConsultaEmpresasViewModel(IEmpresaRepositorio empresaRepositorio) 
            : base(empresaRepositorio, "Consulta de Empresas")
        {
            Carregar();
        }
    }
}
