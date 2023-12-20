using HospitalManagementSystem.Domains.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace HospitalManagementSystem.Domains.Common
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        
        public Entity() 
            => Id = Guid.NewGuid();
        
        private readonly List<BaseEvent> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();
        
        public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
        
        public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
        
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
