using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Domains.Entities
{
    public class InDepartment : AuditableEntity
    {
        public DateTime TimeFrom { get; set; }

        public DateTime TimeTo { get; set; }

        public bool ActiveIs { get; set; } = true;

        public ICollection<Document> Documents { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = null!;    
    }
}
