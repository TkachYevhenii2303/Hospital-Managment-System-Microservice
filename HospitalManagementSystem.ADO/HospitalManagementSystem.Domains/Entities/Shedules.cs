using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class Shedules : Entity
    {
        public DateTime TimeStart { get; set; }
        
        public DateTime TimeEnd { get; set; }

        public Guid InDepartmentsId { get; set; }
    }
}
