using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IncidentApp.Repository.Base.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);
        T Read(int id);
        IEnumerable<T> Read();
        IEnumerable<T> Find(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null);
        bool Exists(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null);
    }
}
