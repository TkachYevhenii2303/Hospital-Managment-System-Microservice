using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hospital_Management_System_Applications.Extensions
{
    public static class ApplicationExtension
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.SetupMapper();
            services.SetupMediatR();
        }

        private static void SetupMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void SetupMediatR(this IServiceCollection services) 
        {
            services.AddMediatR(
                configuration => 
                    configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
