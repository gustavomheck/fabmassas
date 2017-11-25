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

        public CadastroFormaViewModel CadastroFormaViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroFormaViewModel == null)
                CadastroFormaViewModel = DependencyFactory.Resolve<CadastroFormaViewModel>();

            CadastroFormaViewModel.EntidadeSelecionada = formaRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroFormaViewModel.EntidadeSelecionada);
        }
    }
}
