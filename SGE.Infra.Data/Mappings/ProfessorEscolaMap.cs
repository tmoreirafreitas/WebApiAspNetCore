using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Mappings
{
    public class ProfessorEscolaMap : IEntityTypeConfiguration<ProfessorEscola>
    {
        public void Configure(EntityTypeBuilder<ProfessorEscola> builder)
        {
            builder.HasKey(t => new { t.IdEscola, t.IdProfessor });
            builder.Property(t=>t.Adimissao)
                .HasDefaultValueSql("getdate()");

            builder.HasOne(t => t.Escola)
                .WithMany(e => e.ListaDeTrabalhos)
                .HasForeignKey(te => te.IdEscola)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Professor)
                .WithMany(e => e.ListaDeTrabalho)
                .HasForeignKey(te => te.IdProfessor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
