
namespace HospitalManagementSystem.Domains.Common.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEventsAsync(IEnumerable<Entity> entitiesWithEvents);
    }
}
