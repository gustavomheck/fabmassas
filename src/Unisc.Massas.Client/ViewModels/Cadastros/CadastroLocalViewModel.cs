using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroLocalViewModel : CadastroViewModelBase<Local>
    {
        private readonly ILocalRepositorio localRepositorio;

        public CadastroLocalViewModel(ILocalRepositorio localRepositorio) : base(localRepositorio, "Cadastro de Local")
        {
            this.localRepositorio = localRepositorio;
        }
    }
}
