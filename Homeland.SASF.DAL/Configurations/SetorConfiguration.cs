using Homeland.SASF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homeland.SASF.Persistencia
{
    public class SetorConfiguration : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder
                .ToTable("Setores");

            builder
                .Property(s => s.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .HasOne<Funcionario>(s => s.Responsavel)
                .WithMany(f => f.Setores)
                .HasForeignKey(s => s.MatriculaResponsavel);
        }
    }
}
