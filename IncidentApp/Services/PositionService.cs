using AutoMapper;
using IncidentApp.Models;
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
    public class PositionService : IBaseService<Position, PositionDto>
    {
        private readonly IBaseRepository<Position> baseRepository;
        private readonly IMapper mapper;
        public int UserId { get; set; }
        public PositionService(IBaseRepository<Position> _baseRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public Position Add(PositionDto entity)
        {
            Position newPosition = mapper.Map<Position>(entity);

            newPosition.CreatedAt = DateTime.Now;
            newPosition.CreatedBy = UserId;

            return baseRepository.Create(newPosition);
        }

        public Position Delete(int id)
        {
            Position position = baseRepository.Read(id);

            if (position == null) return null;

            position.IsDeleted = true;

            return baseRepository.Update(position);
        }

        public bool Exists(Expression<Func<Position, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<Position> Find(Expression<Func<Position, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public Position Get(int id)
        {
            Position entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }
        public IEnumerable<Position> GetAll()
        {            
            return baseRepository.TableInstance().Include(x => x.Department).Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).ToList();
        }
    
        public Position Update(PositionDto entity)
        {
            Position position = baseRepository.Read(entity.Id);
            
            if (position == null) return null;
            
            position.Name = entity.Name;
            position.DepartmentId = entity.DepartmentId;            
            position.UpdatedAt = DateTime.Now;
            position.UpdatedBy = UserId;

            return baseRepository.Update(position);
        }
    }
}
