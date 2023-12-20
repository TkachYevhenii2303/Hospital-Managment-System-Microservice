using HospitalManagementSystem.Controllers.Middleware.Handling;
using HospitalManagementSystem.Domains.Extensions;
using HospitalManagementSystem.Services.Extensions;
using HospitalManagementSystem.Controllers.Extensions;

namespace HospitalManagmentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.RegisterLogger(builder);

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.RegisterSwagger();

            builder.Services.RegisterConnection(builder.Configuration);

            builder.Services.RegisterDomains();

            builder.Services.RegisterServices();

            builder.Services.RegisterAutoMapper();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandling>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API Version");
                    s.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}