using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroClienteViewModel : CadastroViewModelBase<Cliente>
    {
        private readonly IClienteRepositorio clienteRepositorio;

        public CadastroClienteViewModel(IClienteRepositorio clienteRepositorio) : base(clienteRepositorio, "Cadastro de Cliente")
        {
            this.clienteRepositorio = clienteRepositorio;
        }
    }
}
