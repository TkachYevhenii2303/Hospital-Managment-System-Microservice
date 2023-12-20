using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.SeedingOperation.Bogus
{
    public class Seeding
    {
        public IReadOnlyCollection<InDepartment> InDepartments { get; set; } = new List<InDepartment>();

        public IReadOnlyCollection<Patient> Patients { get; set; } = new List<Patient>();

        public IReadOnlyCollection<PatientCase> PatientsCases { get; set; } = new List<PatientCase>();

        public IReadOnlyCollection<AppointmentStatuse> AppointmentsStatuses { get; set; } = new List<AppointmentStatuse>();

        public IReadOnlyCollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public IReadOnlyCollection<StatusHistory> StatusHistories { get; set; } = new List<StatusHistory>();
    }
}
