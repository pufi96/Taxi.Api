using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DatabaseAccess.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class MaintenaceTypeConfiguration : EntityConfiguration<MaintenaceType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<MaintenaceType> builder)
        {
            builder.Property(x => x.MaintenaceTypeName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(x => x.MaintenaceTypeName).IsUnique();
        }
    }
}
