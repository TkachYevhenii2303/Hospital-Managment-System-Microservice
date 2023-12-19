namespace HospitalManagementSystem.Domains.Common.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedDateTime { get; set; }

        DateTime? UpdatedDateTime { get; set; }
    }
}
