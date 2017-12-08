using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaEmpresasViewModel : ConsultaViewModelBase<Empresa>
    {
        private readonly IEmpresaRepositorio empresaRepositorio;

        public ConsultaEmpresasViewModel(IEmpresaRepositorio empresaRepositorio) 
            : base(empresaRepositorio, "Consulta de Empresas", "Edição de Empresa")
        {
            this.empresaRepositorio = empresaRepositorio;
        }

        public CadastroEmpresaViewModel CadastroEmpresaViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroEmpresaViewModel == null)
                CadastroEmpresaViewModel = DependencyFactory.Resolve<CadastroEmpresaViewModel>();

            CadastroEmpresaViewModel.EntidadeSelecionada = empresaRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroEmpresaViewModel.EntidadeSelecionada);
        }
    }
}
