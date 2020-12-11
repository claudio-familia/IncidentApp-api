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
    public class EmployeeService : IBaseService<Employee, EmployeeDto>
    {
        private readonly IBaseRepository<Employee> baseRepository;
        private readonly IMapper mapper;
        public int UserId { get; set; }
        public EmployeeService(IBaseRepository<Employee> _baseRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            baseRepository = _baseRepository;
            mapper = _mapper;
            UserId = int.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
        }

        public Employee Add(EmployeeDto entity)
        {
            Employee newEmployee = mapper.Map<Employee>(entity);

            newEmployee.CreatedAt = DateTime.Now;
            newEmployee.CreatedBy = UserId;
            newEmployee.Status = StatusConstant.Active;

            return baseRepository.Create(newEmployee);
        }

        public Employee Delete(int id)
        {
            Employee employee = baseRepository.Read(id);

            if (employee == null) return null;

            employee.IsDeleted = true;

            return baseRepository.Update(employee);
        }

        public bool Exists(Expression<Func<Employee, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).Any();
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> filter = null)
        {
            return baseRepository.Find(filter).Where(x => !x.IsDeleted).ToList();
        }

        public Employee Get(int id)
        {
            Employee entity = baseRepository.Read(id);

            if (!entity.IsDeleted) return entity;

            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            return baseRepository.TableInstance()
                                 .Include(x => x.Position)
                                 .Include(x => x.User)
                                 .Where(x => !x.IsDeleted)
                                 .OrderByDescending(x => x.Id)
                                 .ToList();
        }

        public Employee Update(EmployeeDto entity)
        {
            Employee employee = baseRepository.Read(entity.Id);

            if (employee == null) return null;

            employee.Name = entity.Name;
            employee.LastName = entity.LastName;
            employee.Cedula = entity.Cedula;
            employee.Email = entity.Email;
            employee.PhoneNumber = entity.PhoneNumber;
            employee.BornDate = entity.BornDate;
            employee.PositionId = entity.PositionId;
            employee.UserId = entity.UserId;            
             
            employee.UpdatedAt = DateTime.Now;
            employee.UpdatedBy = UserId;

            return baseRepository.Update(employee);
        }
    }
}
