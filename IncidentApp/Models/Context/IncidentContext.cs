using IncidentApp.Models.Configurations;
using IncidentApp.Services.Contracts;
using IncidentApp.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models.Context
{
    public class IncidentContext : DbContext
    {
        private readonly CryptographyUtils cryptography;
        private readonly IConfiguration configuration;
        public IncidentContext(DbContextOptions<IncidentContext> options, 
                               IConfiguration _configuration) : base(options)
        {
            cryptography = new CryptographyUtils();
            configuration = _configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new IncidentConfiguration());
            builder.ApplyConfiguration(new IncidentHistoryConfiguration());
            builder.ApplyConfiguration(new PositionConfiguration());
            builder.ApplyConfiguration(new PriorityConfiguration());
            builder.ApplyConfiguration(new SLAConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            
            builder.Entity<User>(us => {
                us.HasData(new User
                {
                    Id = 1,
                    Username = "Administrator",
                    Password = cryptography.Encrypt("1234", configuration["Authentication:SecretKey"])
                });
            });
        }
    }
}
