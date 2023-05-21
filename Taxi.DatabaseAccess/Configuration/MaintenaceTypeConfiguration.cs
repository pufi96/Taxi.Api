using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class MaintenaceTypeConfiguration : EntityConfiguration<MaintenaceType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<MaintenaceType> builder)
        {
            builder.Property(x => x.MaintenaceTypeName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(x => x.MaintenaceTypeName).IsUnique();
        }
    }
}
