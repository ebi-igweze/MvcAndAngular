using PhotoGallery.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PhotoGallery.Data
{
    class DataRepository :IDataRepository
    {
        private readonly DbContext _dbContext;
        public DataRepository( DbContext db)
        {
            _dbContext = db;
        }

        public void Add<T>(T item) where T : class
        {
            _dbContext.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : class
        {
            _dbContext.Set<T>().Remove(item);
        }

        public T GetByID<T>(int id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }

            _dbContext.Entry(entity);
        }
    }
}
