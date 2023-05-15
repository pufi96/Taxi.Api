using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DatabaseAccess.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class CarModelConfiguration : EntityConfiguration<CarModel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<CarModel> builder)
        {
            builder.Property(x => x.CarModelName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasOne(x => x.CarBrand)
                    .WithMany()
                    .HasForeignKey(x => x.CarBrandId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
