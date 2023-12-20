using HospitalManagementSystem.Domains.Generics.Interfaces;
using HospitalManagementSystem.Domains.Repositories;
using HospitalManagementSystem.Domains.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;


namespace HospitalManagementSystem.Domains.Generics
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private readonly IDbTransaction _transaction;

        private readonly SqlConnection _connection;

        public IEmployeeRepository EmployeesRepository { get; set; }

        public Unit_of_Work(IDbTransaction transaction, SqlConnection connection)
        {
            _transaction = transaction;

            _connection = connection;

            EmployeesRepository = new EmployeeRepository(_connection, _transaction);
        }

        public void Dispose() => _transaction.Dispose();

        public void Configurations() => _transaction.Commit();
    }
}
