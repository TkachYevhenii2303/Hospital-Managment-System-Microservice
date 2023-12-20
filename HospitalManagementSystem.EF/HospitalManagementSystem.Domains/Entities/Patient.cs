using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class Patient : Entity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public ICollection<PatientCase> PatientsCases { get; set; } = null!;
    }
}
