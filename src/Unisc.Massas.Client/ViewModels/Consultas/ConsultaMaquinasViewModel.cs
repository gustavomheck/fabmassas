using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaMaquinasViewModel : ConsultaViewModelBase<Maquina>
    {
        private readonly IMaquinaRepositorio maquinaRepositorio;

        public ConsultaMaquinasViewModel(IMaquinaRepositorio maquinaRepositorio) 
            : base(maquinaRepositorio, "Consulta de Máquina", "Edição de Máquina")
        {
            this.maquinaRepositorio = maquinaRepositorio;
        }
    }
}
