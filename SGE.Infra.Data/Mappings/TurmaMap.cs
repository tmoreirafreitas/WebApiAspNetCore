using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGE.Domain.Entities;

namespace SGE.Infra.Data.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            var converter = new EnumToStringConverter<Turno>();
            builder.HasKey(t => t.IdTurma);
            builder.Property(t => t.Codigo).HasColumnType("varchar(7)").HasMaxLength(7).IsRequired();
            builder.Property(t => t.Sala).HasColumnType("varchar(25)").HasMaxLength(25).IsRequired();
            builder.Property(t => t.Turno).HasConversion(converter);
        }
    }
}
