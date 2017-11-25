using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroFormaViewModel : CadastroViewModelBase<Forma>
    {
        private readonly IFormaRepositorio formaRepositorio;

        public CadastroFormaViewModel(IFormaRepositorio formaRepositorio) : base(formaRepositorio, "Cadastro de Forma")
        {
            this.formaRepositorio = formaRepositorio;
        }
    }
}
