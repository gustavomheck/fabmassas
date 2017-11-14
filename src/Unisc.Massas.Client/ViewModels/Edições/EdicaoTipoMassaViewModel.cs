using System;
using Unisc.Massas.Core;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class EdicaoTipoMassaViewModel : EdicaoViewModelBase<TipoMassa>
    {
        private readonly IFormaRepositorio formaRepositorio;
        private readonly IMaquinaRepositorio maquinaRepositorio;
        private Forma[] _formas;
        private Maquina[] _maquinas;

        public EdicaoTipoMassaViewModel(TipoMassa entidade, string viewName) : base(entidade, viewName)
        {
            formaRepositorio = DependencyFactory.Resolve<IFormaRepositorio>();
            maquinaRepositorio = DependencyFactory.Resolve<IMaquinaRepositorio>();
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

        public string PesoBase
        {
            get => EntidadeSelecionada?.PesoBase.ToDoubleString();
            set
            {
                if (Double.TryParse(value, out double result))
                    EntidadeSelecionada.PesoBase = result;
            }
        }

        public string ValorBase
        {
            get => EntidadeSelecionada?.ValorBase.ToDecimalString();
            set
            {
                if (Decimal.TryParse(value, out decimal result))
                    EntidadeSelecionada.ValorBase = result;
            }
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
