using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Service
{
    public interface IDataRepository
    {
        IQueryable<T> Query<T>();
        IQueryable<T> Query<T>(params Expression<Func<T, object>>[] include);
        T GetByID<T>(int id);
        void Add<T>(T item);
        void Delete<T>(T item);
        void Update<T>(T item);
        void SaveChanges();
    }
}
