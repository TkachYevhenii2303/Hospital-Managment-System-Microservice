using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Domains.Entities
{
    public class Appointment : AuditableEntity
    {
        public DateTime AppointmentStartTime { get; set; }

        public DateTime AppointmentEndTime { get; set; }

        public PatientCase PatientCases { get; set; } = null!;

        public Guid PatientCasesId { get; set; }

        public InDepartment InDepartment { get; set; } = null!;

        public Guid InDepartmentsId { get; set; }
    }
}
