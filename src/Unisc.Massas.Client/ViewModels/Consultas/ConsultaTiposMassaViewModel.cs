using PropertyChanged;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConsultaTiposMassaViewModel : ConsultaViewModelBase<TipoMassa>
    {
        private readonly ITipoMassaRepositorio tipoMassaRepositorio;

        public ConsultaTiposMassaViewModel(ITipoMassaRepositorio tipoMassaRepositorio) : base(tipoMassaRepositorio, "Consulta de Tipos de Massa")
        {
            this.tipoMassaRepositorio = tipoMassaRepositorio;            
        }

        public CadastroTipoMassaViewModel CadastroTipoMassaViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroTipoMassaViewModel == null)
            {
                CadastroTipoMassaViewModel = DependencyFactory.Resolve<CadastroTipoMassaViewModel>();
                CadastroTipoMassaViewModel.ViewName = "Edição de Tipo de Massa";
            }

            CadastroTipoMassaViewModel.EntidadeSelecionada = tipoMassaRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroTipoMassaViewModel.EntidadeSelecionada);
        }
    }
}
