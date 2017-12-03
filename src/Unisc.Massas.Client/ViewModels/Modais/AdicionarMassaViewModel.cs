using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class AdicionarMassaViewModel : ViewModelBase
    {
        public AdicionarMassaViewModel(ITipoMassaRepositorio tipoMassaRepositorio)
        {
            TiposMassas = tipoMassaRepositorio.GetAllAsArray();
            Quantidade = 1;
        }

        public int Quantidade { get; set; }
        public TipoMassa TipoMassaSelecionado { get; set; }
        public TipoMassa[] TiposMassas { get; set; }        
        public bool IsValid => Quantidade > 0;
    }
}
