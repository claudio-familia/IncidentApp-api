using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Repository.Base.Contracts;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IncidentApp.Services
{
    public class UserService : IBaseService<User, UserDto>
    {
        private readonly IBaseRepository<User> baseRepository;
        private readonly IMapper mapper;
        private readonly IAuthService authService;
        public int UserId { get; set; }
        public UserService(IBaseRepository<User> _baseRepository, 
                           IMapper _mapper, 
                           IHttpContextAccessor httpContextAccessor,
                           IAuthService _authService)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            authService = _authService;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public User Add(UserDto entity)
        {
            User newUser = mapper.Map<User>(entity);

            newUser.Password = authService.Encrypt(entity.Password);

            newUser.CreatedAt = DateTime.Now;
            newUser.CreatedBy = UserId;

            return baseRepository.Create(newUser);
        }

        public User Delete(int id)
        {
            User user = baseRepository.Read(id);

            if (user == null) return null;

            user.IsDeleted = true;

            return baseRepository.Update(user);
        }

        public bool Exists(Expression<Func<User, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public User Get(int id)
        {
            User entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return baseRepository.Read().Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).ToList();
        }

        public User Update(UserDto entity)
        {
            User user = baseRepository.Read(entity.Id);

            if (user == null) return null;

            user.Username = entity.Username;
            user.Password = entity.Password;

            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = UserId;

            return baseRepository.Update(user);
        }
    }
}
