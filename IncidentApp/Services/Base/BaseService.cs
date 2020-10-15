using IncidentApp.Repository.Base.Contracts;
using IncidentApp.Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IncidentApp.Services.Base
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : class where TDto : class
    {
        private readonly IBaseRepository<T> baseRepository;
        public BaseService(IBaseRepository<T> _baseRepository)
        {
            baseRepository = _baseRepository;
        }

        public TDto Add(T entity)
        {
            return baseRepository.Create(entity);
        }

        public bool Exists(Expression<Func<T, bool>> filter = null)
        {
            return baseRepository.Exists(filter);
        }

        public IEnumerable<TDto> Find(Expression<Func<T, bool>> filter = null)
        {
            return baseRepository.Find(filter);
        }

        public TDto Get(int id)
        {
            return baseRepository.Read(id);
        }

        public IEnumerable<TDto> GetAll()
        {
            return baseRepository.Read();
        }

        public TDto Update(T entity)
        {
            return baseRepository.Update(entity);
        }
    }
}
