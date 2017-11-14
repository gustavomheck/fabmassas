using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Unisc.Massas.Data.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        bool Delete(TEntity obj, out string errorMessage, bool saveChanges = true);
        bool DeleteRange(IEnumerable<TEntity> objects, out string errorMessage, bool saveChanges = true);
        void Detach(TEntity obj);
        TEntity Find(params object[] keyValues);
        TEntity GetById(int id);
        ObservableCollection<TEntity> GetAll();
        Task<ObservableCollection<TEntity>> GetAllAsync();
        ObservableCollection<TEntity> GetAllAsNoTracking();        
        Task<ObservableCollection<TEntity>> GetAllAsNoTrackingAsync();
        TEntity[] GetAllAsArray();
        Task<TEntity[]> GetAllAsArrayAsync();
        object GetOriginalValue(TEntity obj, string propertyName);
        DbPropertyValues GetOriginalValues(TEntity obj);
        bool Insert(TEntity obj, out string errorMessage, bool saveChanges = true);
        void Rollback();
        void Rollback(TEntity obj);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        bool Update(TEntity obj, out string errorMessage, bool saveChanges = true);
    }
}
