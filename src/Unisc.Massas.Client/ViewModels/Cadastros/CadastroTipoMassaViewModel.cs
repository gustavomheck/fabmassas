using PropertyChanged;
using System;
using Unisc.Massas.Core;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CadastroTipoMassaViewModel : CadastroViewModelBase<TipoMassa>
    {
        private readonly IFormaRepositorio formaRepositorio;
        private readonly IMaquinaRepositorio maquinaRepositorio;

        public CadastroTipoMassaViewModel(ITipoMassaRepositorio tipoMassaRepositorio,
                                          IFormaRepositorio formaRepositorio,
                                          IMaquinaRepositorio maquinaRepositorio)
            : base(tipoMassaRepositorio, "Cadastro de Tipo de Massa")
        {
            this.formaRepositorio = formaRepositorio;
            this.maquinaRepositorio = maquinaRepositorio;

            Carregar();
        }

        public Forma[] Formas { get; set; }
        public Maquina[] Maquinas { get; set; }
        
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
