using HospitalManagementSystem.Domains.Generics;
using HospitalManagementSystem.Domains.Repositories.Interfaces;
using HospitalManagementSystem.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.Domains.Repositories
{
    public class InDepartmentsRepository : GenericRepository<InDepartments>, IInDepartmentRepository
    {
        public InDepartmentsRepository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "InDepartments") { }
    }
}
