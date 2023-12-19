using AutoMapper;
using HospitalManagementSystem.Domains.Generics;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using HospitalManagementSystem.Mapping;
using HospitalManagementSystem.Services.Services;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using Serilog;
using HospitalManagementSystem.Controllers.Middleware.Handling;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HospitalManagmentSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hospital Management System Data Model in Swagger!",
                    Description = "Visiting a hospital or a clinic is never pleasant, but it would be even worse if our health records were in chaos. Not so long ago, all medical documents were in paper form. \nThis not only polluted the environment, it slowed down the whole process. Fortunately for us, technology has had a significant impact in the medical record field. Most health records are automated, which saves a lot of bother."
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services.AddScoped<SqlConnection>(configurations => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IDbTransaction>(configurations =>
            {
                SqlConnection connection = configurations.GetRequiredService<SqlConnection>();
                connection.Open();
                return connection.BeginTransaction();
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnit_of_Work, Unit_of_Work>();
            builder.Services.AddScoped<IEmployeesService, EmployeesService>();

            builder.Services.AddScoped(options => new MapperConfiguration(configurations =>
            {
                configurations.AddProfile(new Mapping(options.GetService<IUnit_of_Work>()));
            }).CreateMapper());

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            builder.Host.ConfigureLogging(logging =>
            {
                logging.AddSerilog();
                logging.SetMinimumLevel(LogLevel.Information);
            }).UseSerilog();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandling>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger API Version");
                    s.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}