using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.Configurations
{
    internal class StatusHistoriesConfigurations : IEntityTypeConfiguration<StatusHistory>
    {
        public void Configure(EntityTypeBuilder<StatusHistory> builder)
        {
            builder
                .HasOne(x => x.AppointmentsStatus)
                .WithMany(x => x.StatusHistories)
                .HasForeignKey(fk => fk.AppointmentStatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
