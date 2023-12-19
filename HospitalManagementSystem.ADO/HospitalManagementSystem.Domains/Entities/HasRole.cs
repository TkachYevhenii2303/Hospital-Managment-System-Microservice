using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class HasRole : Entity
    {
        public Guid EmployeesId { get; set; }

        public Guid PositionId { get; set; }
    }
}
