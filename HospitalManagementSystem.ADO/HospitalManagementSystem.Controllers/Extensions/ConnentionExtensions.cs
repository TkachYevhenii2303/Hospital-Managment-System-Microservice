using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Reflection;

namespace HospitalManagementSystem.Controllers.Extensions
{
    public static class ConnentionExtensions
    {
        public static void RegisterConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupConnection(configuration);
        }

        private static void SetupConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<SqlConnection>(configurations => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbTransaction>(configurations =>
            {
                SqlConnection connection = configurations.GetRequiredService<SqlConnection>();
                connection.Open();
                return connection.BeginTransaction();
            });
        }
    }
}
