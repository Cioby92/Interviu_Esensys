using Essensys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Essensys.Infrastructure.Persistence.Configurations
{
    class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Transaction);
            builder.Property(x => x.ExpirationDate)
                .IsRequired();
        }
    }
}
