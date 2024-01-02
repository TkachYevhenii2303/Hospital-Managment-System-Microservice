using Hospital_Management_System_Applications.Extensions;
using Hospital_Management_System_Infrastructure.Extensions;
using Hospital_Management_System_Persistence.Extensions;
using Hospital_Management_System_WEB_API.Extensions;

namespace HospitalManagementSystem.Controllers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.RegisterApplication();

            builder.Services.RegisterInfrastructure();
            
            builder.Services.RegistratePersistence(builder.Configuration);
            
            builder.Services.RegistratePresentation();
            
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}