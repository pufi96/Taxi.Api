using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DatabaseAccess.Entities;

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
