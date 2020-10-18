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
    public class UserService : IBaseService<User, UserDto>
    {
        public UserService()
        {
        }

        public User Add(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Update(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
