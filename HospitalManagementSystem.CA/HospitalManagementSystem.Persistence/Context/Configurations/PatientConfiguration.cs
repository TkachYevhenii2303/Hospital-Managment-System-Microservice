using HospitalManagementSystem.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.Domains.Configurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasMany(x => x.PatientsCases)
                .WithOne(x => x.Patients)
                .HasForeignKey(fk => fk.PatientsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasMany(x => x.Documents)
                .WithOne(x => x.Patients)
                .HasForeignKey(fk => fk.PatientsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
