using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Domain.Models
{
    public class UnidadeMedida : EntityBase
    {
        public UnidadeMedida()
        {
            Produtos = new ObservableCollection<Produto>();
        }

        [Required(ErrorMessage = "Informe o nome da unidade")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o a sigla da unidade")]
        public string Sigla { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

        public override IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>()
            {
                { "Nome", "Unidade de Medida" },
                { "Sigla", "Sigla" },
            };
        }

        public override bool Filtrar(object obj, string propertyName, string value)
        {
            var unidade = (UnidadeMedida)obj;

            switch (propertyName)
            {
                case "Nome":
                    return unidade.Nome.ToUpper().Contains(value.ToUpper());
                case "Sigla":
                    return unidade.Sigla.ToUpper().Contains(value.ToUpper());
                default:
                    return true;
            }
        }
    }
}
