using IncidentApp.Repository.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IncidentApp.Services.Base.Contracts
{
    public interface IBaseService<T, TDto> where T : class where TDto : class
    {
        TDto Add(T entity);
        TDto Update(T entity);
        TDto Get(int id);
        IEnumerable<TDto> GetAll();
        IEnumerable<TDto> Find(Expression<Func<T, bool>> filter = null);
        bool Exists(Expression<Func<T, bool>> filter = null);
    }
}
