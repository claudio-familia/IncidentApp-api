using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using IncidentApp.Repository.Base;
using IncidentApp.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Services.Configuration
{
    public static partial class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<Position, PositionDto>, PositionService>();
            services.AddScoped<IBaseService<Department, DepartmentDto>, DepartmentService>();
            services.AddScoped<IBaseService<Employee, EmployeeDto>, EmployeeService>();
            services.AddScoped<IBaseService<User, UserDto>, UserService>();
            services.AddScoped<IBaseService<Incident, IncidentDto>, IncidentService>();
            services.AddScoped<IBaseService<IncidentHistory, IncidentHistoryDto>, IncidentHistoryService>();
            services.AddScoped<IBaseService<SLA, SLADto>, SLAService>();
            services.AddScoped<IBaseService<Priority, PriorityDto>, PriorityService>();
        }
    }
}
