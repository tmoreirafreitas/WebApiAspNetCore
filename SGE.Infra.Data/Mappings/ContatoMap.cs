using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Mappings
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(c => c.IdContato);
            builder.Property(c => c.Telefone).HasColumnType("varchar(14)").HasMaxLength(14).IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.HasOne(c => c.Pessoa).WithOne(p => p.Contato);
        }
    }
}
