using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class InDepartments : Entity
    {
        public DateTime TimeFrom { get; set; }
        
        public DateTime TimeTo { get; set; }

        public bool ActiveIs { get; set; } = true;

        public Guid EmployeesId { get; set; }

        public Guid DepartmentsId { get; set; }
    }
}
