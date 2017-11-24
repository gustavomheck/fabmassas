using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaClientesViewModel : ConsultaViewModelBase<Cliente>
    {
        private readonly IClienteRepositorio clienteRepositorio;

        public ConsultaClientesViewModel(IClienteRepositorio clienteRepositorio) 
            : base(clienteRepositorio, "Consulta de Clientes", "Edição de Cliente")
        {
            this.clienteRepositorio = clienteRepositorio;
        }

        public CadastroClienteViewModel CadastroClienteViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroClienteViewModel == null)
                CadastroClienteViewModel = DependencyFactory.Resolve<CadastroClienteViewModel>();

            CadastroClienteViewModel.EntidadeSelecionada = clienteRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroClienteViewModel.EntidadeSelecionada);
        }
    }
}
