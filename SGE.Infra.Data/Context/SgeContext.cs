using System.IO;
using SGE.Domain.Entities;
using SGE.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SGE.Infra.Data.Context
{
    public class SgeContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public DbSet<Trabalha> Trabalhas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaDisciplina> TurmaDisciplinas { get; set; }
        public DbSet<TurmaEscola> EscolaTurmas { get; set; }

        public SgeContext()
        {

        }
        public SgeContext(DbContextOptions<SgeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());            
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new EscolaMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new ProfessorDisciplinaMap());
            modelBuilder.ApplyConfiguration(new TrabalhaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaDisciplinaMap());
            modelBuilder.ApplyConfiguration(new TurmaEscolaMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
