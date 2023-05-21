using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class ShiftConfiguration : EntityConfiguration<Shift>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Shift> builder)
        {
            builder.Property(x => x.ShiftStart)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.Car)
                    .WithMany()
                    .HasForeignKey(x => x.CarId)
                    .OnDelete(DeleteBehavior.Restrict);                    
        }
    }
}
