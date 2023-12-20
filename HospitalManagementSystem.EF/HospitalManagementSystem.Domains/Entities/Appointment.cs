using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class Appointment : Entity
    {
        public DateTime AppointmentStartTime { get; set; }

        public DateTime AppointmentEndTtime { get; set; }

        public PatientCase PatientsCases { get; set; } = null!;

        public Guid PatientCasesId { get; set; }

        public InDepartment InDepartment { get; set; } = null!;

        public Guid InDepartmentsId { get; set; }

        public AppointmentStatuse AppointmentsStatuses { get; set; } = null!;

        public Guid AppointmentsStatusesId { get; set; }

        public ICollection<StatusHistory> StatusHistories { get; set; } = null!;
    }
}
