using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Unisc.Massas.Core.Logging;
using Unisc.Massas.Data.Context;
using Unisc.Massas.Data.Interfaces;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorio<TEntity> where TEntity : class, IEntity
    {
        internal DbContext _dbContext;
        internal DbSet<TEntity> _dbSet;        

        public RepositorioBase()
        {
            _dbContext = MassasContext.Instance;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public bool Delete(TEntity obj, out string errorMessage, bool saveChanges = true)
        {
            try
            {
                _dbSet.Remove(GetById(obj.Id));

                if (saveChanges)
                    _dbContext.SaveChanges();

                errorMessage = String.Empty;
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                errorMessage = GetEnhancedValidationException(dbEx);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Erro ao deletar " + typeof(TEntity));

                errorMessage = ex.Message;
                return false;
            }
        }

        public bool DeleteRange(IEnumerable<TEntity> objects, out string errorMessage, bool saveChanges = true)
        {
            try
            {
                foreach (var obj in new List<TEntity>(objects))
                {
                    _dbContext.Entry(obj).State = EntityState.Deleted;
                }

                if (saveChanges)
                    _dbContext.SaveChanges();

                errorMessage = String.Empty;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Erro ao deletar " + typeof(TEntity));

                errorMessage = ex.Message;
                return false;
            }
        }

        public void Detach(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Detached;
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public TEntity GetById(int id)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, "Id");
            var constant = Expression.Constant(id);
            var equal = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, parameter);

            return _dbSet.FirstOrDefault(lambda);
        }

        public virtual ObservableCollection<TEntity> GetAll()
        {
            return _dbSet.AsObservableCollection();
        }

        public virtual Task<ObservableCollection<TEntity>> GetAllAsync()
        {
            return Task.Run(() => { return _dbSet.AsObservableCollection(); });
        }

        public virtual ObservableCollection<TEntity> GetAllAsNoTracking()
        {
            return _dbSet.AsNoTracking().AsObservableCollection();
        }

        public virtual Task<ObservableCollection<TEntity>> GetAllAsNoTrackingAsync()
        {
            return Task.Run(() => { return _dbSet.AsNoTracking().AsObservableCollection(); });
        }

        public virtual TEntity[] GetAllAsArray()
        {
            return _dbSet.ToArray();
        }

        public virtual Task<TEntity[]> GetAllAsArrayAsync()
        {
            return Task.Run(() => { return _dbSet.ToArray(); });
        }

        public object GetOriginalValue(TEntity obj, string propertyName)
        {
            return _dbContext.Entry(obj).OriginalValues[propertyName];
        }

        public DbPropertyValues GetOriginalValues(TEntity obj)
        {
            return _dbContext.Entry(obj).OriginalValues;
        }

        public virtual bool Insert(TEntity obj, out string errorMessage, bool saveChanges = true)
        {
            try
            {
                _dbContext.Entry(obj).State = EntityState.Added;

                if (saveChanges)
                    _dbContext.SaveChanges();

                errorMessage = String.Empty;
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                errorMessage = GetEnhancedValidationException(dbEx);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Erro ao adicionar " + typeof(TEntity));

                errorMessage = ex.Message;
                return false;
            }
        }

        public void Rollback()
        {
            foreach (DbEntityEntry entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }

        public void Rollback(TEntity obj)
        {
            if (obj != null)
            {
                DbEntityEntry<TEntity> entry = _dbContext.Entry(obj);

                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.Run(() => { return _dbContext.SaveChanges(); });
        }

        public virtual bool Update(TEntity obj, out string errorMessage, bool saveChanges = true)
        {
            try
            {
                _dbContext.Entry(obj).State = EntityState.Modified;

                if (saveChanges)
                    _dbContext.SaveChanges();

                errorMessage = String.Empty;
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                errorMessage = GetEnhancedValidationException(dbEx);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Erro ao atualizar " + typeof(TEntity));

                if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    errorMessage = ex.InnerException.InnerException.Message;
                else
                    errorMessage = ex.Message;

                return false;
            }
        }

        protected string GetEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

            var fullErrorMessage = String.Join("; ", errorMessages);
            var exceptionMessage = String.Concat(e.Message, " Ocorreram os seguintes erros de validação: ", fullErrorMessage);

            return exceptionMessage;
        }
    }
}
