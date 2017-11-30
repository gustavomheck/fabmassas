using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class AdicionarLocalViewModel : ModalViewModelBase<Local>
    {
        public AdicionarLocalViewModel()
        {
        }
        
        public AdicionarLocalViewModel(Local local) : base(local)
        {
        }
    }
}
