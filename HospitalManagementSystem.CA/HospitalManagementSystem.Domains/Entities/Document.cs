using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Domains.Entities
{
    public class Document : AuditableEntity
    {
        public string DocumentsTitle { get; set; } = string.Empty;

        public string DocumentsLink { get; set; } = string.Empty;

        public string DocumentsDetails { get; set; } = string.Empty;

        public DocumentType DocumentTypes { get; set; } = null!;

        public Guid DocumentsTypesId { get; set; }

        public Patient Patients { get; set; } = null!;

        public Guid PatientsId { get; set; }

        public PatientCase PatientsCases { get; set; } = null!;

        public Guid PatientCaseId { get; set; }

        public InDepartment InDepartment { get; set; } = null!;

        public Guid InDepartmentId { get; set; }
    }
}
