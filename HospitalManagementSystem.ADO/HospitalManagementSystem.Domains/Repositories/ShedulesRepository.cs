using HospitalManagementSystem.Domains.Generics;
using HospitalManagementSystem.Domains.Repositories.Interfaces;
using HospitalManagementSystem.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.Domains.Repositories
{
    public class ShedulesRepository : GenericRepository<Shedules>, IShedulesRepository
    {
        public ShedulesRepository(SqlConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Shedules") { }
    }
}
