using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Mappings
{
    public class EscolaMap : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {
            builder.HasKey(e => e.IdEscola);
            builder.Property(e => e.Cnpj)
                .HasColumnType("varchar(19)")
                .HasMaxLength(19)
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(e => e.Endereco)
                .WithMany(e => e.ListaDeEscolas)
                .HasForeignKey(e => e.IdEndereco)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
