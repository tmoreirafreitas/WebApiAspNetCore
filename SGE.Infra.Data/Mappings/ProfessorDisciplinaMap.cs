using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;

namespace SGE.Infra.Data.Mappings
{
    public class ProfessorDisciplinaMap : IEntityTypeConfiguration<ProfessorDisciplina>
    {
        public void Configure(EntityTypeBuilder<ProfessorDisciplina> builder)
        {
            builder.HasKey(pd => new { pd.IdDisciplina, pd.IdProfessor });
            builder.HasOne(pd => pd.Disciplina)
                .WithMany(d => d.ListaDeProfessores)
                .HasForeignKey(pd => pd.IdDisciplina);

            builder.HasOne(pd => pd.Professor)
                .WithMany(d => d.ListaDeDisciplinas)
                .HasForeignKey(pd => pd.IdProfessor);
        }
    }
}
