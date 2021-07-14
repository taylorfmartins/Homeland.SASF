using Homeland.SASF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SASF.Persistencia.Configurations
{
    internal class OcorrenciaConfiguration : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.
                HasKey(o => o.numero);

            builder
                .Property(o => o.matricula)
                .HasColumnType("nvarchar(200)")
                .IsRequired();

            builder
                .Property(o => o.data)
                .HasColumnType("datetime")
                .IsRequired();

            builder
               .Property(o => o.respostaEstado)
               .HasColumnType("varchar(500)")
               .IsRequired();

            builder
             .Property(o => o.respostaSintomas)
             .HasColumnType("varchar(500)")
             .IsRequired();

            builder
            .Property(o => o.respostaVacina)
            .HasColumnType("varchar(500)")
            .IsRequired();

            builder
            .Property(o => o.solicitarHistorico)
            .HasColumnType("bit")
            .IsRequired();
        }
    }
}