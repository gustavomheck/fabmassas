using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Domain.Models
{
    public class Maquina : EntityBase
    {
        public Maquina()
        {
            TiposMassas = new ObservableCollection<TipoMassa>();
        }

        [Required(ErrorMessage = "Informe o nome da máquina")]
        public string Nome { get; set; }
        public virtual ICollection<TipoMassa> TiposMassas { get; set; }

        public override IDictionary<string, string> GetColunasFiltro()
        {
            return new Dictionary<string, string>()
            {
                { "Nome", "Máquina" },
            };
        }

        public override bool Filtrar(object obj, string propertyName, string value)
        {
            var maquina = (Maquina)obj;

            switch (propertyName)
            {
                case "Nome":
                    return maquina.Nome.ToUpper().Contains(value.ToUpper());
                default:
                    return true;
            }
        }
    }
}
