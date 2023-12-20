using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class PatientCase : Entity
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal TotalCost { get; set; } = decimal.Zero;

        public Patient Patients { get; set; } = null!;

        public Guid PatientsId { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = null!;
    }
}
