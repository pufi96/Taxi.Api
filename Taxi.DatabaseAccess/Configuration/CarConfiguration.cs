using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class CarConfiguration : EntityConfiguration<Car>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Registration)
                    .IsRequired()
                    .HasMaxLength(10);

            builder.Property(x => x.Color)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.HasOne(x => x.CarModel)
                    .WithMany(x => x.Cars)
                    .HasForeignKey(x => x.CarModelId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FuelType)
                    .WithMany(x => x.Cars)
                    .HasForeignKey(x => x.FuelTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
