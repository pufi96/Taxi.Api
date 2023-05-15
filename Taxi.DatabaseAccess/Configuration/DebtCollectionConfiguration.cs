﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.DatabaseAccess.Entities;

namespace Taxi.DatabaseAccess.Configuration
{
    public class DebtCollectionConfiguration : EntityConfiguration<DebtCollection>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<DebtCollection> builder)
        {
            builder.Property(x => x.DebtCollectionPrice)
                    .IsRequired();

            //builder.HasOne(x => x.Debtor)
            //        .WithMany()
            //        .HasForeignKey(x => x.DebtorId)
            //        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
