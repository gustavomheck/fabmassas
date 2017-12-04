using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaLocalViewModel : ConsultaViewModelBase<Local>
    {
        private readonly ILocalRepositorio localRepositorio;

        public ConsultaLocalViewModel(ILocalRepositorio localRepositorio) 
            : base(localRepositorio, "Consulta de Locais", "Edição de Local")
        {
            this.localRepositorio = localRepositorio;
        }

        public AdicionarLocalViewModel CadastroLocalViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroLocalViewModel == null)
                CadastroLocalViewModel = DependencyFactory.Resolve<AdicionarLocalViewModel>();

            CadastroLocalViewModel.EntidadeSelecionada = localRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroLocalViewModel.EntidadeSelecionada);
        }
    }
}
