using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;
using System;

namespace SGE.Infra.Data.Mappings
{
    class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            
            builder.HasKey(p => p.IdProfessor);
            builder.Property(p => p.Cpf)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.Matricula)
                .HasColumnType("varchar(7)")
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(p => p.Nome)
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
        }
    }
}
