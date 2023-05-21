using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi.Domain.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class DebtorConfiguration : EntityConfiguration<Debtor>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Debtor> builder)
        {
            builder.Property(x => x.DebtorFirstName)
                    .IsRequired()
                    .HasMaxLength(50);
            
            builder.Property(x => x.DebtorLastName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasMany(x => x.DebtCollections)
                    .WithOne(x => x.Debtor)
                    .HasForeignKey(x => x.DebtorId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
