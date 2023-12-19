using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class Department : Entity
    {
        public string Title { get; set; } = string.Empty;
       
        public Guid HospitalId { get; set; }
    }
}
