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
    public class DepartmentService : IBaseService<Department, DepartmentDto>
    {
        private readonly IBaseRepository<Department> baseRepository;
        private readonly IMapper mapper;
        public int UserId { get; set; }
        public DepartmentService(IBaseRepository<Department> _baseRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public Department Add(DepartmentDto entity)
        {
            Department newDepartment = mapper.Map<Department>(entity);

            newDepartment.CreatedAt = DateTime.Now;
            newDepartment.CreatedBy = UserId;

            return baseRepository.Create(newDepartment);
        }

        public Department Delete(int id)
        {
            Department department = baseRepository.Read(id);

            if (department == null) return null;

            department.IsDeleted = true;

            return baseRepository.Update(department);
        }

        public bool Exists(Expression<Func<Department, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<Department> Find(Expression<Func<Department, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public Department Get(int id)
        {
            Department entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }

        public IEnumerable<Department> GetAll()
        {
            return baseRepository.Read().Where(x => !x.IsDeleted).ToList();
        }

        public Department Update(DepartmentDto entity)
        {
            Department department = baseRepository.Read(entity.Id);

            if (department == null) return null;

            department.Name = entity.Name;

            department.UpdatedAt = DateTime.Now;
            department.UpdatedBy = UserId;

            return baseRepository.Update(department);
        }
    }
}
