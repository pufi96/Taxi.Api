using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class LocationPriceConfiguration : EntityConfiguration<LocationPrice>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<LocationPrice> builder)
        {
            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.LocationStartId).IsRequired();

            builder.Property(x => x.LocationEndId).IsRequired();

            builder.HasOne(x => x.LocationStart)
                    .WithMany(x => x.LocationPricesStart)
                    .HasForeignKey(x => x.LocationStartId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LocationEnd)
                    .WithMany(x => x.LocationPricesEnd)
                    .HasForeignKey(x => x.LocationEndId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
