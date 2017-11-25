using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels.Cadastros
{
    public class CadastroUnidadeMedidaViewModel : CadastroViewModelBase<UnidadeMedida>
    {
        private readonly IUnidadeMedidaRepositorio unidadeMedidaRepositorio;

        public CadastroUnidadeMedidaViewModel(IUnidadeMedidaRepositorio unidadeMedidaRepositorio) : base(unidadeMedidaRepositorio, "Cadastro de Unidade de Medida")
        {
            this.unidadeMedidaRepositorio = unidadeMedidaRepositorio;
        }
    }
}
