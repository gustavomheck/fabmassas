using System;
using Unisc.Massas.Core;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels.Cadastros
{
    public class CadastroTipoMassaViewModel : CadastroViewModelBase<TipoMassa>
    {
        private readonly IFormaRepositorio formaRepositorio;
        private readonly IMaquinaRepositorio maquinaRepositorio;
        private Forma[] _formas;
        private Maquina[] _maquinas;

        public CadastroTipoMassaViewModel(ITipoMassaRepositorio tipoMassaRepositorio,
                                          IFormaRepositorio formaRepositorio,
                                          IMaquinaRepositorio maquinaRepositorio)
            : base(tipoMassaRepositorio, "Cadastro de Tipo de Massa")
        {
            this.formaRepositorio = formaRepositorio;
            this.maquinaRepositorio = maquinaRepositorio;
        }

        public Forma[] Formas
        {
            get => _formas;
            set => SetValue(ref _formas, value);
        }

        public Maquina[] Maquinas
        {
            get => _maquinas;
            set => SetValue(ref _maquinas, value);
        }
        
        protected override void Carregar()
        {
            base.Carregar();

            ApplicationHelper.ExecuteAction(new Action(
                async () =>
                {
                    Formas = await formaRepositorio.GetAllAsArrayAsync();
                    Maquinas = await maquinaRepositorio.GetAllAsArrayAsync();
                }));
        }
    }
}
