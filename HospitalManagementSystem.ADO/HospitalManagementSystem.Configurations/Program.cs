using HospitalManagementSystem.Configurations.Configurations;
using HospitalManagementSystem.Domains.Repositories;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.SeedingOperations.Bogus;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HospitalManagementSystem.Configurations
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connections = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnections"].ConnectionString);

            await connections.OpenAsync();

            var transaction = connections.BeginTransaction();

            await SeedingCollections(connections, transaction); 

            Console.ReadLine();
        }

        private static async Task SeedingCollections(SqlConnection connections, IDbTransaction transaction)
        {
            var employee = new Configurations<EmployeesRepository, Employees>(Seeding.SeedEmployees, new EmployeesRepository(connections, transaction), transaction);

            await employee.SeedRepository();

            var positions = new Configurations<PositionRepository, Position>(Seeding.SeedPositions, new PositionRepository(connections, transaction), transaction);

            await positions.SeedRepository();

            var hasRoles = new Configurations<HasRoleRepository, HasRole>(Seeding.SeedHasRoles, new HasRoleRepository(connections, transaction), transaction);  

            await hasRoles.SeedRepository();

            var hospital = new Configurations<HospitalRepository, Hospital>(Seeding.SeedHospitals, new HospitalRepository(connections, transaction), transaction);

            await hospital.SeedRepository();

            var departments = new Configurations<DepartmentRepository, Department>(Seeding.SeedDepartments, new DepartmentRepository(connections, transaction), transaction);

            await departments.SeedRepository();

            var inDepartments = new Configurations<InDepartmentsRepository, InDepartments>(Seeding.SeedInDepartments, new InDepartmentsRepository(connections, transaction), transaction);

            await inDepartments.SeedRepository();

            var shedules = new Configurations<ShedulesRepository, Shedules>(Seeding.SeedShedules, new ShedulesRepository(connections, transaction), transaction);

            await shedules.SeedRepository();

            await Console.Out.WriteLineAsync("All tables was inserted!!!");

            transaction.Commit();
        }
    }
}