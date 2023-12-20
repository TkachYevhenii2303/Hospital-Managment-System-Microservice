using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Domains.Entities
{
    public class DocumentType : AuditableEntity
    {
        public string TypesTitle { get; set; } = string.Empty;

        public ICollection<Document> Documents { get; set; } = null!;
    }
}
