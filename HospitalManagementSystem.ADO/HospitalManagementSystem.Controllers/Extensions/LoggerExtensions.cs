using Serilog;
using Microsoft.Extensions.Configuration;

namespace HospitalManagementSystem.Controllers.Extensions
{
    public static class LoggerExtensions
    {
        public static void RegisterLogger(this IServiceCollection services, WebApplicationBuilder builder)
            => services.SetupLogger(builder);

        private static void SetupLogger(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

           builder.Logging.AddSerilog();
        }
    }
}
