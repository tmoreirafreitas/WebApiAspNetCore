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
            builder.Property(p => p.Cpf).HasColumnType("varchar(15)").HasMaxLength(15).IsRequired();
            builder.Property(p => p.Matricula).HasColumnType("varchar(7)").HasMaxLength(7).IsRequired();
            builder.Property(p => p.Nome).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.HasOne(p => p.Contato);
        }
    }
}
