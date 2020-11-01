using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Essensys.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Essensys.Infrastructure.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {

        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ammount)
                .IsRequired();
            builder.Property(x => x.Id)
                .IsRequired();
             builder.Property(x => x.SourceCurrency)
                .IsRequired();
            builder.Property(x => x.DestinationCurrency)
                .IsRequired();
            builder.Property(x => x.Expeditor_id)
                .IsRequired();
              builder.Property(x => x.Destinatar_id)
                .IsRequired();
           

        }
    }
}
