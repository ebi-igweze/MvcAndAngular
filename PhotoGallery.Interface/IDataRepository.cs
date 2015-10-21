using System;
using System.Linq;
using System.Linq.Expressions;

namespace PhotoGallery.Interface
{
    public interface IDataRepository
    {
        IQueryable<T> Query<T>() where T : class;
        IQueryable<T> Query<T>(params Expression<Func<T, object>>[] include) where T : class;
        T GetByID<T>(int id) where T : class;
        void Add<T>(T item) where T : class;
        void Delete<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        void SaveChanges();
    }
}
