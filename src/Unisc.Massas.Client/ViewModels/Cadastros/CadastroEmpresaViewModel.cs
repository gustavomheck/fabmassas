using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroEmpresaViewModel : CadastroViewModelBase<Empresa>
    {
        private readonly IEmpresaRepositorio empresaRepositorio;

        public CadastroEmpresaViewModel(IEmpresaRepositorio empresaRepositorio) 
            : base(empresaRepositorio, "Cadastro de Empresa")
        {
            this.empresaRepositorio = empresaRepositorio;
        }
    }
}
