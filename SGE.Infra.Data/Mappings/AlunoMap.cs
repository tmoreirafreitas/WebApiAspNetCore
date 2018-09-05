using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.IdAluno);
            builder.HasOne(a => a.Contato);
            builder.HasOne(a => a.Escola).WithMany(e => e.ListaDeAlunos).HasForeignKey(a => a.IdAluno);
            builder.HasOne(a => a.Turma).WithMany(t => t.ListaDeAlunos).HasForeignKey(a => a.IdAluno);
            builder.HasOne(a => a.Endereco);
            builder.Property(a => a.Matricula).HasColumnType("varchar(20)").HasMaxLength(20).IsRequired();
            builder.Property(a => a.Nome).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();            
        }
    }
}
