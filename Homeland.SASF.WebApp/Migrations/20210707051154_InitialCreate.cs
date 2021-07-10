using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homeland.SASF.WebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Matricula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Setor = table.Column<int>(nullable: false),
                    Gestor = table.Column<bool>(nullable: false, defaultValue: false),
                    DataAdmissao = table.Column<DateTime>(nullable: false),
                    Cargo = table.Column<string>(nullable: true),
                    TipoNotificacao = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Porte = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImagemPrincipal = table.Column<string>(type: "nvarchar(254)", nullable: true),
                    ImagemLado = table.Column<string>(type: "nvarchar(254)", nullable: true),
                    ImagemBrincando = table.Column<string>(type: "nvarchar(254)", nullable: true),
                    URLPerfil = table.Column<string>(type: "nvarchar(254)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NomeOng = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EnderecoONG = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NumeroEnderecoONG = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MatriculaResponsavel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setores_Funcionarios_MatriculaResponsavel",
                        column: x => x.MatriculaResponsavel,
                        principalTable: "Funcionarios",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setores_MatriculaResponsavel",
                table: "Setores",
                column: "MatriculaResponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
