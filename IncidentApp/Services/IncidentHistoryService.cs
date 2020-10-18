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
    public class IncidentHistoryService : IBaseService<IncidentHistory, IncidentHistoryDto>
    {
        public IncidentHistoryService()
        {
        }

        public IncidentHistory Add(IncidentHistoryDto entity)
        {
            throw new NotImplementedException();
        }

        public IncidentHistory Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<IncidentHistory, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IncidentHistory> Find(Expression<Func<IncidentHistory, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IncidentHistory Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IncidentHistory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IncidentHistory Update(IncidentHistoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
