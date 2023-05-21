using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class LocationPriceConfiguration : EntityConfiguration<LocationPrice>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<LocationPrice> builder)
        {
            builder.HasOne(x => x.LocationStart)
                    .WithMany()
                    .HasForeignKey(x => x.LocationStartId)
                    .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.LocationEnd)
                    .WithMany()
                    .HasForeignKey(x => x.LocationEndId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
