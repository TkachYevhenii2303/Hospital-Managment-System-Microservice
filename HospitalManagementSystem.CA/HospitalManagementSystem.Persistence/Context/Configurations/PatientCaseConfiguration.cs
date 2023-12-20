using HospitalManagementSystem.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.Domains.Configurations
{
    internal class PatientCaseConfiguration : IEntityTypeConfiguration<PatientCase>
    {
        public void Configure(EntityTypeBuilder<PatientCase> builder)
        {
            builder
               .HasMany(x => x.Documents)
               .WithOne(x => x.PatientsCases)
               .HasForeignKey(fk => fk.PatientCaseId)
               .IsRequired()
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.PatientCases)
                .HasForeignKey(fk => fk.PatientCasesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
