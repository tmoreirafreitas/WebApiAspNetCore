using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;

namespace SGE.Infra.Data.Mappings
{
    class TurmaDisciplinaMap : IEntityTypeConfiguration<TurmaDisciplina>
    {
        public void Configure(EntityTypeBuilder<TurmaDisciplina> builder)
        {
            builder.HasKey(td => new { td.IdTurma, td.IdDisciplina });
            builder.HasOne(td => td.Turma).WithMany(t => t.ListaDeDisciplinas).HasForeignKey(td => td.IdTurma);
            builder.HasOne(td => td.Disciplina).WithMany(t => t.ListaDeTurmas).HasForeignKey(td => td.IdDisciplina);
            builder.Property(td => td.DataInicio).HasColumnType("datetime");
            builder.Property(td => td.DataTermino).HasColumnType("datetime");
        }
    }
}
