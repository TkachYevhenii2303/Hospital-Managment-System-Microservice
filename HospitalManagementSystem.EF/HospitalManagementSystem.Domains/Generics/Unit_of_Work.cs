using HospitalManagementSystem.Context;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using HospitalManagementSystem.Domains.Repositories;
using HospitalManagementSystem.Domains.Repositories.Interfaces;

namespace HospitalManagementSystem.Domains.Generics
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private readonly ApplicationDbContext _context;

        public Unit_of_Work(ApplicationDbContext context)
        {
            _context = context;

            AppointmentsRepository = new AppointmentRepository(_context);

            PatientsRepository = new PatientRepository(_context);  
        }
       
        public IAppointmentRepository AppointmentsRepository { get; private set; }

        public IPatientRepository PatientsRepository { get; private set; }

        public async void Configurations()
            => await _context.SaveChangesAsync();

        public async void Dispose()
            => await _context.DisposeAsync();
    }
}
