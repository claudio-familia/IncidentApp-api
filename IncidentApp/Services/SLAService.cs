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
    public class SLAService : IBaseService<SLA, SLADto>
    {
        public SLAService()
        {
        }

        public SLA Add(SLADto entity)
        {
            throw new NotImplementedException();
        }

        public SLA Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<SLA, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SLA> Find(Expression<Func<SLA, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public SLA Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SLA> GetAll()
        {
            throw new NotImplementedException();
        }

        public SLA Update(SLADto entity)
        {
            throw new NotImplementedException();
        }
    }
}
