using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaFormasViewModel : ConsultaViewModelBase<Forma>
    {
        private readonly IFormaRepositorio formaRepositorio;

        public ConsultaFormasViewModel(IFormaRepositorio formaRepositorio) 
            : base(formaRepositorio, "Consulta de Formas", "Edição de Forma")
        {
            this.formaRepositorio = formaRepositorio;
        }
    }
}
