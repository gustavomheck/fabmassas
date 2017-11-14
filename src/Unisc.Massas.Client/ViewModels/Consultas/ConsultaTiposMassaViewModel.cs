using Unisc.Massas.Client.Views;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaTiposMassaViewModel : ConsultaViewModelBase<TipoMassa>
    {
        private readonly ITipoMassaRepositorio tipoMassaRepositorio;

        public ConsultaTiposMassaViewModel(ITipoMassaRepositorio tipoMassaRepositorio) : base(tipoMassaRepositorio, "Consulta de Tipos de Massa")
        {
            this.tipoMassaRepositorio = tipoMassaRepositorio;
        }

        protected override void Editar()
        {
            base.Editar();

            var view = new EdicaoTipoMassaView()
            {
                DataContext = new EdicaoTipoMassaViewModel(tipoMassaRepositorio.GetById(EntidadeSelecionada.Id), "Editar Tipo de Massa")
            };

            EditarAsync(view);
        }
    }
}
