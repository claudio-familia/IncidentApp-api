using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IncidentApp.Services.Contracts
{
    public interface IBaseService<T, Dto> where T : class where Dto : class
    {
        T Add(Dto entity);
        T Update(Dto entity);
        T Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> filter = null);
        bool Exists(Expression<Func<T, bool>> filter = null);
    }
}
