using IncidentApp.Controllers.Base;
using IncidentApp.Controllers.Base.Contracts;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Controllers.Configuration
{
    public static partial class ControllerConfiguration
    {
        public static void AddApiControllers(this IServiceCollection services)
        {
            services.AddScoped<IBaseController<Position, PositionDto>, BaseController<Position, PositionDto>>();
            services.AddScoped<IBaseController<Department, DepartmentDto>, BaseController<Department, DepartmentDto>>();
            services.AddScoped<IBaseController<Employee, EmployeeDto>, BaseController<Employee, EmployeeDto>>();
            services.AddScoped<IBaseController<User, UserDto>, BaseController<User, UserDto>>();
            services.AddScoped<IBaseController<Incident, IncidentDto>, BaseController<Incident, IncidentDto>>();
            services.AddScoped<IBaseController<IncidentHistory, IncidentHistoryDto>, BaseController<IncidentHistory, IncidentHistoryDto>>();
            services.AddScoped<IBaseController<SLA, SLADto>, BaseController<SLA, SLADto>>();
            services.AddScoped<IBaseController<Priority, PriorityDto>, BaseController<Priority, PriorityDto>>();
        }
    }
}
