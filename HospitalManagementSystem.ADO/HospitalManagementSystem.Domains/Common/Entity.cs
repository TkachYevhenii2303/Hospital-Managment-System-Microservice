using HospitalManagementSystem.Domains.Common.Interfaces;

namespace HospitalManagementSystem.Domains.Common
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        
        public DateTime CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        
            CreatedDateTime = DateTime.Now;
            
            UpdatedDateTime = DateTime.Now;
        }
    }
}
