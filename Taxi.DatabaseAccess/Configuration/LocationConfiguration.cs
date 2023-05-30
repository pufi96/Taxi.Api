using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class LocationConfiguration : EntityConfiguration<Location>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.LocationName)
                    .IsRequired()
                    .HasMaxLength(50);
        }
    }
}
