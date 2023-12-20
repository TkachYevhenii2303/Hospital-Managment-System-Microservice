using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HospitalManagementSystem.Controllers.Extensions
{
    public static class SwaggerExtensions
    {
        public static void RegisterSwagger(this IServiceCollection services)
            => services.SetupSwagger();

        private static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hospital Management System",
                    Description = "\r\nIntroducing our Hospital System App, a cutting-edge solution designed to streamline and optimize employee management and scheduling within healthcare institutions. This user-friendly application empowers hospital staff with efficient tools to manage their schedules seamlessly."
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
