using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Domains.Entities
{
    public class PatientCase : AuditableEntity
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal TotalCost { get; set; } = decimal.Zero;

        public Patient Patients { get; set; } = null!;

        public Guid PatientsId { get; set; }

        public ICollection<Document> Documents { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = null!;
    }
}
