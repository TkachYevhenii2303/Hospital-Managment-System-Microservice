using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class StatusHistory : Entity
    {
        public string Details { get; set; } = string.Empty;

        public Appointment Appointments { get; set; } = null!;

        public Guid AppointmentsId { get; set; }

        public AppointmentStatuse AppointmentsStatus { get; set; } = null!;

        public Guid AppointmentStatusId { get; set; }
    }
}
