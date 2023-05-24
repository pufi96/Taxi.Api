using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class MaintenaceTypeConfiguration : EntityConfiguration<MaintenanceType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<MaintenanceType> builder)
        {
            builder.Property(x => x.MaintenanceTypeName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(x => x.MaintenanceTypeName).IsUnique();
        }
    }
}
