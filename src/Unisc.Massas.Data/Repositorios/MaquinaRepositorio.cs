using System.Linq;
using System.Threading.Tasks;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Repositorios
{
    public class MaquinaRepositorio : RepositorioBase<Maquina>, IMaquinaRepositorio
    {
        public override Task<Maquina[]> GetAllAsArrayAsync()
        {
            return Task.Run(() => { return _dbSet.OrderBy(x => x.Nome).ToArray(); });
        }
    }
}
