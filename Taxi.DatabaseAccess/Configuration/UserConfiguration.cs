using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasIndex(x => x.Username)
                    .IsUnique();

            builder.HasIndex(x => x.Email)
                    .IsUnique();

            builder.Property(x => x.Password)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);
            
            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.HasOne(x => x.UserRole)
                    .WithMany(x => x.Users)
                    .HasForeignKey(x => x.UserRoleId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
