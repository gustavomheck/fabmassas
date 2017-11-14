using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class EscolherEncomendaViewModel : ViewModelBase
    {
        private int _quantidade;
        private TipoMassa _tipoMassaSelecionado;
        private TipoMassa[] _tiposMassas;

        public EscolherEncomendaViewModel()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public int Quantidade
        {
            get => _quantidade;
            set
            {
                SetValue(ref _quantidade, value);
                OnPropertyChanged(nameof(IsValid));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TipoMassa TipoMassaSelecionado
        {
            get => _tipoMassaSelecionado;
            set => SetValue(ref _tipoMassaSelecionado, value);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public TipoMassa[] TiposMassas
        {
            get => _tiposMassas;
            set => SetValue(ref _tiposMassas, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsValid
        {
            get => Quantidade > 0;
        }
    }
}
