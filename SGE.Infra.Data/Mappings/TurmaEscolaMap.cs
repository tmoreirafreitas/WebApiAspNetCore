using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.Domain.Entities;


namespace SGE.Infra.Data.Mappings
{
    public class TurmaEscolaMap : IEntityTypeConfiguration<TurmaEscola>
    {
        public void Configure(EntityTypeBuilder<TurmaEscola> builder)
        {
            builder.HasKey(te => new { te.IdEscola, te.IdTurma });
            builder.HasOne(te => te.Escola)
                .WithMany(e => e.ListaDeTurmas)
                .HasForeignKey(te => te.IdEscola)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(te => te.Turma)
                .WithMany(e => e.ListaDeEscolas)
                .HasForeignKey(te => te.IdTurma)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
