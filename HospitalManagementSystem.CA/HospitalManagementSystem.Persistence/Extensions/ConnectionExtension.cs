using Hospital_Management_System_Persistence.Context;
using Hospital_Management_System_Persistence.Repositories;
using HospitalManagementSystem.Application.Generics.Interfaces;
using HospitalManagementSystem.Application.Repositories.Interfaces;
using HospitalManagementSystem.Persistence.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_Management_System_Persistence.Extensions
{
    public static class ConnectionExtension
    {
        public static void RegistratePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupConnection(configuration);
            services.SetupRepositories();
        }

        private static void SetupConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    builder => builder.MigrationsAssembly("HospitalManagementSystem.Migrations"));
            });
        }

        private static void SetupRepositories(this IServiceCollection services)
        {
            services
               .AddTransient(typeof(IUnit_of_Work), typeof(Unit_of_Work))
               .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
               .AddTransient<IPatientsRepository, PatientsRepository>();
        }
    }
}
