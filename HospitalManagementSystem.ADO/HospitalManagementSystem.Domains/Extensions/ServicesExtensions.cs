using HospitalManagementSystem.Domains.Generics;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementSystem.Domains.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterDomains(this IServiceCollection services)
            => services.Services();

        private static void Services(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnit_of_Work, Unit_of_Work>();
        }
    }
}
