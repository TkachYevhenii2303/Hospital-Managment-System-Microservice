using HospitalManagementSystem.Context;
using HospitalManagementSystem.Domains.Generics;
using HospitalManagementSystem.Domains.Repositories.Interfaces;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.Domains.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) 
            : base(context) { }
    }
}
