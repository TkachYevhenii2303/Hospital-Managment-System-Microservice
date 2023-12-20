using AutoMapper;

namespace HospitalManagementSystem.Controllers.Extensions
{
    public static class AutoMappperExtensions
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
            => services.SetupAutoMapper();

        private static void SetupAutoMapper(this IServiceCollection services)
        {
            services.AddScoped(options => new MapperConfiguration(configurations =>
            {
                configurations.AddProfile(new Mapping.AutoMapper());
            }).CreateMapper());
        }
    }
}
