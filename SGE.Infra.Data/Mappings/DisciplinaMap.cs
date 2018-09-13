using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Mappings
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(d => d.IdDisciplina);
            builder.Property(d => d.Nome)
                .HasColumnType("varchar(60)")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(d => d.CargaHoraria)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(d => d.Codigo)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
