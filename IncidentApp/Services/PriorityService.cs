using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IncidentApp.Services
{
    public class PriorityService : IBaseService<Priority, PriorityDto>
    {
        public PriorityService()
        {
        }

        public Priority Add(PriorityDto entity)
        {
            throw new NotImplementedException();
        }

        public Priority Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Priority, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Priority> Find(Expression<Func<Priority, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Priority Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Priority> GetAll()
        {
            throw new NotImplementedException();
        }

        public Priority Update(PriorityDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
