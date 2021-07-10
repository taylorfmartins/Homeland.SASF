﻿// <auto-generated />
using System;
using Homeland.SASF.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Homeland.SASF.WebApp.Migrations
{
    [DbContext(typeof(SASFContext))]
    [Migration("20210707051154_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Homeland.SASF.Model.Funcionario", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Cargo");

                    b.Property<DateTime>("DataAdmissao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Endereco");

                    b.Property<bool>("Gestor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Setor");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TipoNotificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Matricula");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Homeland.SASF.Model.PetPerfeito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EnderecoONG")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagemBrincando")
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("ImagemLado")
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("ImagemPrincipal")
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeOng")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumeroEnderecoONG");

                    b.Property<string>("Porte")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("URLPerfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(254)");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Homeland.SASF.Model.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatriculaResponsavel");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MatriculaResponsavel");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("Homeland.SASF.Model.Setor", b =>
                {
                    b.HasOne("Homeland.SASF.Model.Funcionario", "Responsavel")
                        .WithMany("Setores")
                        .HasForeignKey("MatriculaResponsavel")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
