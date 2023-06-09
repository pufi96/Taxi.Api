using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class CarConfiguration : EntityConfiguration<Car>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Registration)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.Property(x => x.Color)
                    .IsRequired()
                    .HasMaxLength(50);

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
