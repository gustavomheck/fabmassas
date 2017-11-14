using System.Linq;
using System.Threading.Tasks;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Repositorios
{
    public class FormaRepositorio : RepositorioBase<Forma>, IFormaRepositorio
    {
        public override Task<Forma[]> GetAllAsArrayAsync()
        {
            return Task.Run(() => { return _dbSet.OrderBy(x => x.Nome).ToArray(); });
        }
    }
}
