using HospitalManagementSystem.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.Domains.Configurations
{
    internal class InDepartmentConfiguration : IEntityTypeConfiguration<InDepartment>
    {
        public void Configure(EntityTypeBuilder<InDepartment> builder)
        {
            builder
                .HasMany(x => x.Documents)
                .WithOne(x => x.InDepartment)
                .HasForeignKey(fk => fk.InDepartmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.InDepartment)
                .HasForeignKey(fk => fk.InDepartmentsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
