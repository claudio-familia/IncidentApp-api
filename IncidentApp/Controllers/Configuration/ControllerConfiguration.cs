using IncidentApp.Controllers.Base;
using IncidentApp.Controllers.Base.Contracts;
using IncidentApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Controllers.Configuration
{
    public static partial class ControllerConfiguration
    {
        public static void AddApiControllers(this IServiceCollection services)
        {
            services.AddScoped<IBaseController<Position>, BaseController<Position>>();
            services.AddScoped<IBaseController<Department>, BaseController<Department>>();
            services.AddScoped<IBaseController<Employee>, BaseController<Employee>>();
            services.AddScoped<IBaseController<User>, BaseController<User>>();
            services.AddScoped<IBaseController<Incident>, BaseController<Incident>>();
            services.AddScoped<IBaseController<IncidentHistory>, BaseController<IncidentHistory>>();
            services.AddScoped<IBaseController<SLA>, BaseController<SLA>>();
            services.AddScoped<IBaseController<Priority>, BaseController<Priority>>();
        }
    }
}
