using System.Linq;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Repositorios
{
    public class MaquinaRepositorio : RepositorioBase<Maquina>, IMaquinaRepositorio
    {
        public override Maquina[] GetAllAsArray()
        {
            return _dbSet.OrderBy(x => x.Nome).ToArray();
        }
    }
}
