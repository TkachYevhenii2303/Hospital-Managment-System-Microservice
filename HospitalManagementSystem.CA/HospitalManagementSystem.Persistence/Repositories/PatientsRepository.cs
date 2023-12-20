using HospitalManagementSystem.Domains.Entities;
using Hospital_Management_System_Persistence.Context;
using HospitalManagementSystem.Application.Repositories.Interfaces;
using HospitalManagementSystem.Application.Generics.Interfaces;

namespace Hospital_Management_System_Persistence.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly IGenericRepository<Patient> _repository;

        private readonly ApplicationDbContext _context;

        public PatientsRepository(IGenericRepository<Patient> repository, ApplicationDbContext context)
        {
            _repository = repository;

            _context = context;
        }
    }
}
