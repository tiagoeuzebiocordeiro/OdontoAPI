using Microsoft.EntityFrameworkCore;
using OdontoAPI.Models;

namespace OdontoAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Meu banco já tá criado, então n preciso de Dbsets. só faço um mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DentistaModel>().ToTable("tb_dentistas");
            modelBuilder.Entity<PacienteModel>().ToTable("tb_pacientes");
            modelBuilder.Entity<ConsultaModel>().ToTable("tb_consultas");
            base.OnModelCreating(modelBuilder);
        }
    }
}
