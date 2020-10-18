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
    public class IncidentHistoryService : IBaseService<IncidentHistory, IncidentHistoryDto>
    {
        private readonly IBaseRepository<IncidentHistory> baseRepository;
        private readonly IMapper mapper;
        public int UserId { get; set; }
        public IncidentHistoryService(IBaseRepository<IncidentHistory> _baseRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public IncidentHistory Add(IncidentHistoryDto entity)
        {
            IncidentHistory newIncidentHistory = mapper.Map<IncidentHistory>(entity);

            newIncidentHistory.CreatedAt = DateTime.Now;
            newIncidentHistory.CreatedBy = UserId;

            return baseRepository.Create(newIncidentHistory);
        }

        public IncidentHistory Delete(int id)
        {
            IncidentHistory incidentHistory = baseRepository.Read(id);

            if (incidentHistory == null) return null;

            incidentHistory.IsDeleted = true;

            return baseRepository.Update(incidentHistory);
        }

        public bool Exists(Expression<Func<IncidentHistory, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<IncidentHistory> Find(Expression<Func<IncidentHistory, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public IncidentHistory Get(int id)
        {
            IncidentHistory entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }

        public IEnumerable<IncidentHistory> GetAll()
        {
            return baseRepository.Read().Where(x => !x.IsDeleted).ToList();
        }

        public IncidentHistory Update(IncidentHistoryDto entity)
        {
            IncidentHistory incidentHistory = baseRepository.Read(entity.Id);

            if (incidentHistory == null) return null;

            incidentHistory.IncidentId = entity.IncidentId;
            incidentHistory.Comment = entity.Comment;

            incidentHistory.UpdatedAt = DateTime.Now;
            incidentHistory.UpdatedBy = UserId;

            return baseRepository.Update(incidentHistory);
        }
    }
}
