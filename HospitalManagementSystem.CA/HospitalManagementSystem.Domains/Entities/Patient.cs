using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Domains.Entities
{
    public class Patient : AuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public ICollection<Document> Documents { get; set; } = null!;

        public ICollection<PatientCase> PatientsCases { get; set; } = null!;
    }
}
