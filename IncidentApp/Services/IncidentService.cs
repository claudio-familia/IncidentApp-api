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
    public class IncidentService : IBaseService<Incident, IncidentDto>
    {
        public IncidentService()
        {
        }

        public Incident Add(IncidentDto entity)
        {
            throw new NotImplementedException();
        }

        public Incident Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Incident, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Incident> Find(Expression<Func<Incident, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Incident Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Incident> GetAll()
        {
            throw new NotImplementedException();
        }

        public Incident Update(IncidentDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
