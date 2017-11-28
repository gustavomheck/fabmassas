using System.Linq;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Repositorios
{
    public class FormaRepositorio : RepositorioBase<Forma>, IFormaRepositorio
    {
        public override Forma[] GetAllAsArray()
        {
            return _dbSet.OrderBy(x => x.Nome).ToArray();;
        }
    }
}
