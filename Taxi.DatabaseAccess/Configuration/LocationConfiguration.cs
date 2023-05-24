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

            builder.HasMany(x => x.LocationPricesStart)
                    .WithOne(x => x.LocationStart)
                    .HasForeignKey(x => x.LocationStartId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.LocationPricesEnd)
                    .WithOne(x => x.LocationEnd)
                    .HasForeignKey(x => x.LocationEndId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
