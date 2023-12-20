using HospitalManagementSystem.Context;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Common.Interfaces;
using HospitalManagementSystem.Domains.Generics;
using HospitalManagementSystem.Domains.Repositories.Interfaces;
using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Domains.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context) 
            : base(context) {
        _context = context;
        }

        public async Task<Response<IEnumerable<Patient>>> GetPatientsByDoctorsAsync(IEnumerable<Guid> doctorsId)
        {
            var result = new Response<IEnumerable<Patient>>();

            var query = from patients in _context.Set<Patient>()
                        join patientsCases in _context.Set<PatientCase>() on patients.Id equals patientsCases.PatientsId
                        join appointments in _context.Set<Appointment>() on patientsCases.Id equals appointments.PatientCasesId
                        join inDepartments in _context.Set<InDepartment>() on appointments.InDepartmentsId equals inDepartments.Id
                        where doctorsId.Contains(inDepartments.EmployeesId)
                        select patients;

            result.Data = await query.Distinct().AsNoTracking().ToListAsync();

            result.Message = $"Proccess is Good! We return information ";

            return result;
        }



    }
}
