using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class CadastroMaquinaViewModel : CadastroViewModelBase<Maquina>
    {
        private readonly IMaquinaRepositorio maquinaRepositorio;

        public CadastroMaquinaViewModel(IMaquinaRepositorio maquinaRepositorio) : base(maquinaRepositorio, "Cadastro de Máquina")
        {
            this.maquinaRepositorio = maquinaRepositorio;
        }
    }
}
