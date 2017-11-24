using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaEncomendasViewModel : ConsultaViewModelBase<Encomenda>
    {
        private readonly IEncomendaRepositorio encomendaRepositorio;

        public ConsultaEncomendasViewModel(IEncomendaRepositorio encomendaRepositorio)
            : base(encomendaRepositorio, "Consulta de Encomendas", "Edição de Encomenda")
        {
            this.encomendaRepositorio = encomendaRepositorio;
        }

        public CadastroEncomendaViewModel CadastroEncomendaViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroEncomendaViewModel == null)
                CadastroEncomendaViewModel = DependencyFactory.Resolve<CadastroEncomendaViewModel>();

            CadastroEncomendaViewModel.EntidadeSelecionada = encomendaRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroEncomendaViewModel.EntidadeSelecionada);
        }
    }
}
