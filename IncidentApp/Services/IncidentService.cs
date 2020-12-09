using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Constants;
using IncidentApp.Models.Dtos;
using IncidentApp.Repository.Base.Contracts;
using IncidentApp.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IncidentApp.Services
{
    public class IncidentService : IBaseService<Incident, IncidentDto>
    {
        private readonly IBaseRepository<Incident> baseRepository;
        private readonly IMapper mapper;
        public int UserId { get; set; }
        public IncidentService(IBaseRepository<Incident> _baseRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public Incident Add(IncidentDto entity)
        {
            Incident newIncident = mapper.Map<Incident>(entity);

            newIncident.CreatedAt = DateTime.Now;
            newIncident.CreatedBy = UserId;
            newIncident.ReportedUserId = UserId;
            newIncident.Status = StatusConstant.Active;

            return baseRepository.Create(newIncident);
        }

        public Incident Delete(int id)
        {
            Incident incident = baseRepository.Read(id);

            if (incident == null) return null;

            incident.IsDeleted = true;

            return baseRepository.Update(incident);
        }

        public bool Exists(Expression<Func<Incident, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<Incident> Find(Expression<Func<Incident, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public Incident Get(int id)
        {
            Incident entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }

        public IEnumerable<Incident> GetAll()
        {
            return baseRepository.TableInstance()
                                 .Include(x => x.ReportedUser)
                                 .Include(x => x.AssignedUser)
                                 .Include(x => x.AssignedUser.Employee)
                                 .Include(x => x.Department)
                                 .Include(x => x.Priority)
                                 .Where(x => !x.IsDeleted)
                                 .OrderByDescending(x => x.Id)
                                 .ToList();
        }

        public Incident Update(IncidentDto entity)
        {
            Incident incident = baseRepository.Read(entity.Id);

            if (incident == null) return null;

            incident.ReportedUserId = entity.ReportedUserId;
            incident.AssignedUserId = entity.AssignedUserId;
            incident.PriorityId = entity.PriorityId;
            incident.DepartmentId = entity.DepartmentId;
            incident.Title = entity.Title;
            incident.Description = entity.Description;
            incident.ClosedDate = entity.ClosedDate;
            incident.ClosedComment += incident.ClosedComment != null ? "\n" +entity.ClosedComment : entity.ClosedComment;

            incident.UpdatedAt = DateTime.Now;
            incident.UpdatedBy = UserId;

            if (entity.IsIncidentClosed.HasValue && entity.IsIncidentClosed.Value)
            {
                incident.ClosedDate = DateTime.Now;
            }

            return baseRepository.Update(incident);
        }
    }
}
