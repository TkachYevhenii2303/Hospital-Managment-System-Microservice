using HospitalManagementSystem.Domains.Common.Interfaces;

namespace HospitalManagementSystem.Domains.Common
{
    public class AuditableEntity : Entity, IAuditableEntity
    {
        public DateTime CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
