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

namespace IncidentApp.Services
{
    public class PriorityService : IBaseService<Priority, PriorityDto>
    {
        private readonly IBaseRepository<Priority> baseRepository;
        private readonly IMapper mapper;
        public int UserId { get; set; }
        public PriorityService(IBaseRepository<Priority> _baseRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public Priority Add(PriorityDto entity)
        {
            Priority newPriority = mapper.Map<Priority>(entity);

            newPriority.CreatedAt = DateTime.Now;
            newPriority.CreatedBy = UserId;

            return baseRepository.Create(newPriority);
        }

        public Priority Delete(int id)
        {
            Priority priority = baseRepository.Read(id);

            if (priority == null) return null;

            priority.IsDeleted = true;

            return baseRepository.Update(priority);
        }

        public bool Exists(Expression<Func<Priority, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<Priority> Find(Expression<Func<Priority, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public Priority Get(int id)
        {
            Priority entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }

        public IEnumerable<Priority> GetAll()
        {
            return baseRepository.Read().Where(x => !x.IsDeleted).ToList();
        }

        public Priority Update(PriorityDto entity)
        {
            Priority priority = baseRepository.Read(entity.Id);

            if (priority == null) return null;

            priority.SLAId = entity.SLAId;
            priority.Name = entity.Name;

            priority.UpdatedAt = DateTime.Now;
            priority.UpdatedBy = UserId;

            return baseRepository.Update(priority);
        }
    }
}
