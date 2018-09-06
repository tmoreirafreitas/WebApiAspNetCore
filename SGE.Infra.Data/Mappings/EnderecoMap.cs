using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.IdEndereco);
            builder.Property(e => e.Cep).HasColumnType("varchar(8)").HasMaxLength(8).IsRequired();
            builder.Property(e => e.Bairro).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Cidade).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Complemento).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Logradouro).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Numero).HasColumnType("int").HasMaxLength(100).IsRequired();
            builder.Property(e => e.UF).HasColumnType("char(2)").HasMaxLength(2).IsRequired();
        }
    }
}
