using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class RideConfiguration : EntityConfiguration<Ride>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Ride> builder)
        {            
            builder.HasOne(x => x.LocationPrice)
                    .WithMany()
                    .HasForeignKey(x => x.LocationPriceId);
        }
    }
}
