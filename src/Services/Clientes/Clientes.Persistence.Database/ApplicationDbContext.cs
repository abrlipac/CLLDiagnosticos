using Microsoft.EntityFrameworkCore;
using Clientes.Domain;
using Clientes.Persistence.Database.Configuration;

namespace Clientes.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        )
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Clientes");

            ModelConfig(modelBuilder);
        }

        public DbSet<Paciente> Pacientes { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            PacienteConfiguration.Configure(modelBuilder.Entity<Paciente>());
        }
    }
}
