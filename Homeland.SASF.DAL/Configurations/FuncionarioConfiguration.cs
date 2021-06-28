using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Homeland.SASF.Model;

namespace Homeland.SASF.Persistencia
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.
                HasKey(f => f.Matricula);

            builder
                .Property(f => f.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.Telefone)
                .HasColumnType("nvarchar(15)")
                .IsRequired();

            builder
                .Property(f => f.Email)
                .HasColumnType("nvarchar(60)")
                .IsRequired();

            builder
                .Property(f => f.CPF)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder
                .Property(f => f.Gestor)
                .HasDefaultValue("false");

            builder
                .Property(f => f.TipoNotificacao)
                .HasColumnType("nvarchar(10)")
                .IsRequired()
                .HasConversion<string>(
                    tipo => tipo.ParaString(),
                    texto => texto.ParaTipo()
                );
        }
    }
}
