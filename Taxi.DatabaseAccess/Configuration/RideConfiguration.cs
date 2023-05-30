using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class RideConfiguration : EntityConfiguration<Ride>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Ride> builder)
        {            
            builder.HasOne(x => x.LocationPrice)
                    .WithMany(x => x.Rides)
                    .HasForeignKey(x => x.LocationPriceId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Shift)
                    .WithMany(x => x.Rides)
                    .HasForeignKey(x => x.ShiftId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
