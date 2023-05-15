using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DatabaseAccess.Entities;

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
