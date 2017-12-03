using System.Windows.Input;
using Unisc.Massas.Client.Models;
using Unisc.Massas.Core.Comandos;
using Unisc.Massas.Core.Web;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class AdicionarLocalViewModel : ModalViewModelBase<Local>
    {
        public AdicionarLocalViewModel() : this(null)
        {
        }
        
        public AdicionarLocalViewModel(Local local) : base(local)
        {
            BuscarCepCommand = new DelegateCommand<KeyEventArgs>(BuscarCep);
        }

        public ICommand BuscarCepCommand { get; set; }

        private void BuscarCep(KeyEventArgs e)
        {
            if (e != null && e.Key != Key.Enter) return;

            string cep = EntidadeSelecionada.Cep.ToString().PadLeft(8, '0');
            var viaCep = WebRequest.MakeRequest<ViaCep>($"http://viacep.com.br/ws/{cep}/xml");

            if (viaCep != null)
            {
                EntidadeSelecionada.Cidade = viaCep.Localidade;
                EntidadeSelecionada.Logradouro = viaCep.Logradouro;
                EntidadeSelecionada.Bairro = viaCep.Bairro;
            }
            else
            {
                EntidadeSelecionada.Cidade = "";
                EntidadeSelecionada.Logradouro = "";
                EntidadeSelecionada.Bairro = "";
            }
        }
    }
}
