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
    public class EmployeeService : IBaseService<Employee, EmployeeDto>
    {
        public EmployeeService()
        {
        }

        public Employee Add(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Employee, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee Update(EmployeeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
