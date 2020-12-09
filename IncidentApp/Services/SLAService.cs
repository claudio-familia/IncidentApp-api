using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Constants;
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
    public class SLAService : IBaseService<SLA, SLADto>
    {
        private readonly IBaseRepository<SLA> baseRepository;
        private readonly IMapper mapper;
        public int UserId { get; set; }
        public SLAService(IBaseRepository<SLA> _baseRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public SLA Add(SLADto entity)
        {
            SLA newSLA = mapper.Map<SLA>(entity);

            newSLA.CreatedAt = DateTime.Now;
            newSLA.CreatedBy = UserId;
            newSLA.Status = StatusConstant.Active;

            return baseRepository.Create(newSLA);
        }

        public SLA Delete(int id)
        {
            SLA sla = baseRepository.Read(id);

            if (sla == null) return null;

            sla.IsDeleted = true;

            return baseRepository.Update(sla);
        }

        public bool Exists(Expression<Func<SLA, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<SLA> Find(Expression<Func<SLA, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public SLA Get(int id)
        {
            SLA entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }

        public IEnumerable<SLA> GetAll()
        {
            return baseRepository.Read().Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).ToList();
        }

        public SLA Update(SLADto entity)
        {
            SLA priority = baseRepository.Read(entity.Id);

            if (priority == null) return null;

            priority.Hours = entity.Hours;
            priority.Description = entity.Description;

            priority.UpdatedAt = DateTime.Now;
            priority.UpdatedBy = UserId;

            return baseRepository.Update(priority);
        }
    }
}
