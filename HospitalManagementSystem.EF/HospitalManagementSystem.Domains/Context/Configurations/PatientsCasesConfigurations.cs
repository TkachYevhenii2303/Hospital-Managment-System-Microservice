using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.Configurations
{
    internal class PatientsCasesConfigurations : IEntityTypeConfiguration<PatientCase>
    {
        public void Configure(EntityTypeBuilder<PatientCase> builder)
        {
            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.PatientsCases)
                .HasForeignKey(fk => fk.PatientCasesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
