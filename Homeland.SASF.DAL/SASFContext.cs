using Microsoft.EntityFrameworkCore;
using Homeland.SASF.Model;
using SASF.Persistencia.Configurations;

namespace Homeland.SASF.Persistencia
{
    public class SASFContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Setor> Setors { get; set; }
        public DbSet<PetPerfeito> Pets { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        public SASFContext(DbContextOptions<SASFContext> options)
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .ApplyConfiguration<Funcionario>(new FuncionarioConfiguration())
                .ApplyConfiguration<Setor>(new SetorConfiguration())
                .ApplyConfiguration<PetPerfeito>(new PetPerfeitoConfiguration())
                .ApplyConfiguration<Ocorrencia>(new OcorrenciaConfiguration());
        }
    }
}