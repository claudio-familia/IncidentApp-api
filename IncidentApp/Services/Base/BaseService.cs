using IncidentApp.Repository.Base.Contracts;
using IncidentApp.Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IncidentApp.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> baseRepository;
        public BaseService(IBaseRepository<T> _baseRepository)
        {
            baseRepository = _baseRepository;
        }

        public T Add(T entity)
        {
            return baseRepository.Create(entity);
        }

        public bool Exists(Expression<Func<T, bool>> filter = null)
        {
            return baseRepository.Exists(filter);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null)
        {
            return baseRepository.Find(filter);
        }

        public T Get(int id)
        {
            return baseRepository.Read(id);
        }

        public IEnumerable<T> GetAll()
        {
            return baseRepository.Read();
        }

        public T Update(T entity)
        {
            return baseRepository.Update(entity);
        }
    }
}
