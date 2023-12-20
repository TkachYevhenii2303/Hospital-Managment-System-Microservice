using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class AppointmentStatuse : Entity
    {
        public string StatusTitle { get; set; } = string.Empty; 

        public ICollection<StatusHistory> StatusHistories { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = null!;
    }
}
