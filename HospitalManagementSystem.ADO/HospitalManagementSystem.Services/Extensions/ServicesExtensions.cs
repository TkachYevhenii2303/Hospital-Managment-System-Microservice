using HospitalManagementSystem.Services.Services;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementSystem.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
            => services.Services();

        private static void Services(this IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeesService>();
        }
    }
}
