
namespace HospitalManagementSystem.Domains.Common.Interfaces
{
    public interface IAuditableEntity : IEntity
    {
        DateTime CreatedDateTime { get; set; } 
     
        DateTime? UpdatedDateTime { get; set; }
    }
}
