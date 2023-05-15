using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DatabaseAccess.Entities;

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
