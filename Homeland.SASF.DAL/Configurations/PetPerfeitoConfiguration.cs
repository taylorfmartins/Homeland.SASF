using Homeland.SASF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homeland.SASF.Persistencia
{
    public class PetPerfeitoConfiguration : IEntityTypeConfiguration<PetPerfeito>
    {
        public void Configure(EntityTypeBuilder<PetPerfeito> builder)
        {
            builder
                .Property(f => f.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.Especie)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.Sexo)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.Porte)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.ImagemPrincipal)
                .HasColumnType("nvarchar(254)");

            builder
                .Property(f => f.ImagemLado)
                .HasColumnType("nvarchar(254)");

            builder
                .Property(f => f.ImagemBrincando)
                .HasColumnType("nvarchar(254)");

            builder
                .Property(f => f.URLPerfil)
                .HasColumnType("nvarchar(254)")
                .IsRequired();

            builder
                .Property(f => f.Descricao)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.NomeOng)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.EnderecoONG)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.Cidade)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.Bairro)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.Estado)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(f => f.CEP)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
        }
    }
}
