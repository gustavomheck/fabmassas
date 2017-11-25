using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaUnidadesMedidaViewModel : ConsultaViewModelBase<UnidadeMedida>
    {
        private readonly IUnidadeMedidaRepositorio unidadeMedidaRepositorio;

        public ConsultaUnidadesMedidaViewModel(IUnidadeMedidaRepositorio unidadeMedidaRepositorio) 
            : base(unidadeMedidaRepositorio, "Consulta de Unidade de Medida", "Edição de Unidade de Medida")
        {
            this.unidadeMedidaRepositorio = unidadeMedidaRepositorio;
        }

        public CadastroUnidadeMedidaViewModel CadastroUnidadeMedidaViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroUnidadeMedidaViewModel == null)
                CadastroUnidadeMedidaViewModel = DependencyFactory.Resolve<CadastroUnidadeMedidaViewModel>();

            CadastroUnidadeMedidaViewModel.EntidadeSelecionada = unidadeMedidaRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroUnidadeMedidaViewModel.EntidadeSelecionada);
        }
    }
}
