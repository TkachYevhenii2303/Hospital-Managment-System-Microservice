using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.Configurations
{
    internal class InDepartmentsConfigurations : IEntityTypeConfiguration<InDepartment>
    {
        public void Configure(EntityTypeBuilder<InDepartment> builder)
        {
            builder
                .HasMany(x => x.Appointments)
                .WithOne(x => x.InDepartment)
                .HasForeignKey(fk => fk.InDepartmentsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
