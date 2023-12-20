using Dapper;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Entities.Structures;
using HospitalManagementSystem.Domains.Generics;
using HospitalManagementSystem.Domains.Repositories.Interfaces;
using HospitalManagementSystem.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.Domains.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly SqlConnection connections;

        private readonly IDbTransaction transactions;

        public EmployeeRepository(SqlConnection connection, IDbTransaction transaction) : base(connection, transaction, "Employee")
        {
            connections = connection;

            transactions = transaction;
        }
    }
}
