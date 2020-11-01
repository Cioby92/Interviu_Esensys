using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Essensys.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Essensys.Infrastructure.Persistence.Configurations
{
    public class AccountConfiguration :IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(x => x.IBAN)
                .IsRequired();
            builder.Property(x => x.UserId)
                .IsRequired();
            builder.Property(x => x.LastModifiedBy)
                .IsRequired();
        }
    }
}
