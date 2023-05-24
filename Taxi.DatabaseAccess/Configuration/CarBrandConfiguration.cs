using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class CarBrandConfiguration : EntityConfiguration<CarBrand>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<CarBrand> builder)
        {
            builder.Property(x => x.CarBrandName)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.HasIndex(x => x.CarBrandName)
                    .IsUnique();
        }
    }
}
