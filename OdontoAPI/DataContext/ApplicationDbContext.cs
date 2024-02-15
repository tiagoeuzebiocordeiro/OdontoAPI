using Microsoft.EntityFrameworkCore;
using OdontoAPI.Models;

namespace OdontoAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets para suas entidades
        public DbSet<DentistaModel> Dentistas { get; set; }
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*COMEÇO DE MAPEAMENTO DOS DENTISTAS*/
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
            /*FIM DE MAPEAMENTO DOS DENTISTAS*/


            /*COMEÇO DE MAPEAMENTO DOS PACIENTES*/
            modelBuilder.Entity<PacienteModel>().ToTable("tb_pacientes").Property(p => p.Id).HasColumnName("id_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.Nome).HasColumnName("nome_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.DataNascimento).HasColumnName("data_nasc_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.Cpf).HasColumnName("cpf_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.Endereco).HasColumnName("endereco_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.Telefone).HasColumnName("telefone_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.Email).HasColumnName("email_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.Sexo).HasColumnName("sexo_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.Status).HasColumnName("status_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.DataCadastro).HasColumnName("data_cadastro_paciente");
            modelBuilder.Entity<PacienteModel>().Property(p => p.DataModificacao).HasColumnName("data_modificacao_paciente");
            /*FIM DE MAPEAMENTO DOS PACIENTES*/

            /*COMEÇO DE MAPEAMENTO DAS CONSULTAS*/
            modelBuilder.Entity<ConsultaModel>().ToTable("tb_consultas").Property(c => c.Id).HasColumnName("id_consulta");
            modelBuilder.Entity<ConsultaModel>().Property(c => c.DentistaAssociado).HasColumnName("id_dentista_associado");
            modelBuilder.Entity<ConsultaModel>().Property(c => c.PacienteAssociado).HasColumnName("id_paciente_associado");
            modelBuilder.Entity<ConsultaModel>().Property(c => c.DataConsulta).HasColumnName("data_consulta");
            modelBuilder.Entity<ConsultaModel>().Property(c => c.DataCadastroConsulta).HasColumnName("data_cadastro_consulta");
            modelBuilder.Entity<ConsultaModel>().Property(c => c.DataModificacaoConsulta).HasColumnName("data_modificacao_consulta");
            /*FIM DE MAPEAMENTO DAS CONSULTAS*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
