using Microsoft.EntityFrameworkCore;
using OdontoAPI.Models;

namespace OdontoAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define os DbSets para suas entidades
        public DbSet<DentistaModel> Dentistas { get; set; }
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }


        //Meu banco já tá criado, então n preciso de Dbsets. só faço um mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DentistaModel>().ToTable("tb_dentistas").Property(d => d.Id).HasColumnName("id_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Nome).HasColumnName("nome_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.CodigoCro).HasColumnName("cod_cro_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Especialidade).HasColumnName("especialidade_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Endereco).HasColumnName("endereco_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Telefone).HasColumnName("telefone_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Cpf).HasColumnName("cpf_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Email).HasColumnName("email_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.DataNascimento).HasColumnName("data_nasc_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Sexo).HasColumnName("sexo_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Turno).HasColumnName("turno_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.Status).HasColumnName("status_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.DataCadastro).HasColumnName("data_cadastro_dentista");
            modelBuilder.Entity<DentistaModel>().Property(d => d.DataModificacao).HasColumnName("data_modificacao_dentista");

            modelBuilder.Entity<PacienteModel>().ToTable("tb_pacientes");
            modelBuilder.Entity<ConsultaModel>().ToTable("tb_consultas");
            base.OnModelCreating(modelBuilder);
        }
    }
}
