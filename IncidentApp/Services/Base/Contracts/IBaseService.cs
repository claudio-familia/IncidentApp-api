using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IncidentApp.Services.Base.Contracts
{
    public interface IBaseService<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> filter = null);
        bool Exists(Expression<Func<T, bool>> filter = null);
    }
}
