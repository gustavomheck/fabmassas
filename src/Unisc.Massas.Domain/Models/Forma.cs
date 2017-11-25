using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Domain.Models
{
    public class Forma : EntityBase
    {
        public Forma()
        {
            TiposMassas = new ObservableCollection<TipoMassa>();
        }
        
        [Required(ErrorMessage = "Informe o nome da forma")]
        public string Nome { get; set; }
        public virtual ICollection<TipoMassa> TiposMassas { get; set; }

        public override IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>()
            {
                { "Nome", "Forma" },
            };
        }

        public override bool Filtrar(object obj, string propertyName, string value)
        {
            var forma = (Forma)obj;

            switch (propertyName)
            {
                case "Nome":
                    return forma.Nome.ToUpper().Contains(value.ToUpper());
                default:
                    return true;
            }
        }
    }
}
