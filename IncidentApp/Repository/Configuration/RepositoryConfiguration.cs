using IncidentApp.Models;
using IncidentApp.Repository.Base;
using IncidentApp.Repository.Base.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IncidentApp.Repository.Configuration
{
    public static partial class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Position>, BaseRepository<Position>>();
            services.AddScoped<IBaseRepository<Department>, BaseRepository<Department>>();
            services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<Incident>, BaseRepository<Incident>>();
            services.AddScoped<IBaseRepository<IncidentHistory>, BaseRepository<IncidentHistory>>();
            services.AddScoped<IBaseRepository<SLA>, BaseRepository<SLA>>();
            services.AddScoped<IBaseRepository<Priority>, BaseRepository<Priority>>();
        }
    }
}
