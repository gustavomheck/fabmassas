using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaTiposMassaViewModel : ConsultaViewModelBase<TipoMassa>
    {
        private readonly ITipoMassaRepositorio tipoMassaRepositorio;

        public ConsultaTiposMassaViewModel(ITipoMassaRepositorio tipoMassaRepositorio) 
            : base(tipoMassaRepositorio, "Consulta de Tipos de Massa", "Cadastro de Tipo de Massa")
        {
            this.tipoMassaRepositorio = tipoMassaRepositorio;            
        }

        public CadastroTipoMassaViewModel CadastroTipoMassaViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroTipoMassaViewModel == null)
                CadastroTipoMassaViewModel = DependencyFactory.Resolve<CadastroTipoMassaViewModel>();

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
