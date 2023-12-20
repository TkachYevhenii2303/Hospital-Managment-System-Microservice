using HospitalManagementSystem.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.Domains.Configurations
{
    internal class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder
                .HasOne(x => x.DocumentTypes)
                .WithMany(x => x.Documents)
                .HasForeignKey(fk => fk.DocumentsTypesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
