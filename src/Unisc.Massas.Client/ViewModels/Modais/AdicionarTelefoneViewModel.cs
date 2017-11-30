using System;
using System.ComponentModel.DataAnnotations;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Client.ViewModels
{
    public class AdicionarTelefoneViewModel : ModalViewModelBase<Telefone>
    {
        public AdicionarTelefoneViewModel()
        {
        }

        public AdicionarTelefoneViewModel(Telefone obj) : base(obj)
        {
        }

        [MinLength(8, ErrorMessage = "Informe o número do telefone")]
        public string Telefone
        {
            get => EntidadeSelecionada.Numero > 0 ? EntidadeSelecionada.Numero.ToString() : "";
            set
            {
                EntidadeSelecionada.Numero = value == "" ? 0 : Convert.ToInt32(value.Replace("-", ""));
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public bool IsValid => Telefone.Length >= 8;
    }
}
