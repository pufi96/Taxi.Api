using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class MaintenanceConfiguration : EntityConfiguration<Maintenance>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Maintenance> builder)
        {
            builder.Property(x => x.Mileage)
                   .IsRequired();

            builder.HasOne(x => x.MaintenanceType)
                    .WithMany(x => x.Maintenances)
                    .HasForeignKey(x => x.MaintenanceTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Car)
                    .WithMany(x => x.Maintenances)
                    .HasForeignKey(x => x.CarId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
