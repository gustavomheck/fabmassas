using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class ConsultaMaquinasViewModel : ConsultaViewModelBase<Maquina>
    {
        private readonly IMaquinaRepositorio maquinaRepositorio;

        public ConsultaMaquinasViewModel(IMaquinaRepositorio maquinaRepositorio) 
            : base(maquinaRepositorio, "Consulta de Máquina", "Edição de Máquina")
        {
            this.maquinaRepositorio = maquinaRepositorio;
        }

        public CadastroMaquinaViewModel CadastroMaquinaViewModel { get; set; }

        protected override void Editar()
        {
            if (CadastroMaquinaViewModel == null)
                CadastroMaquinaViewModel = DependencyFactory.Resolve<CadastroMaquinaViewModel>();

            CadastroMaquinaViewModel.EntidadeSelecionada = maquinaRepositorio.GetById(EntidadeSelecionada.Id);
            base.Editar();
        }

        protected override void Salvar()
        {
            base.Salvar();
            Salvar(CadastroMaquinaViewModel.EntidadeSelecionada);
        }
    }
}
