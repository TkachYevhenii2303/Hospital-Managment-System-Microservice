using MediatR;

namespace HospitalManagementSystem.Domains.Common
{
    public class BaseEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
