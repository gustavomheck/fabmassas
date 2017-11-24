using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaLocaisViewModel : ConsultaViewModelBase<Local>
    {
        private readonly ILocalRepositorio localRepositorio;

        public ConsultaLocaisViewModel(ILocalRepositorio localRepositorio) 
            : base(localRepositorio, "Consulta de Local", "Edição de Local")
        {
            this.localRepositorio = localRepositorio;
        }

        public CadastroLocalViewModel CadastroLocalViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroLocalViewModel == null)
                CadastroLocalViewModel = DependencyFactory.Resolve<CadastroLocalViewModel>();

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
