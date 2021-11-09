using Microsoft.EntityFrameworkCore;
using Diagnosticos.Domain;
using Diagnosticos.Persistence.Database.Configuration;

namespace Diagnosticos.Persistence.Database
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

            // Database schema
            modelBuilder.HasDefaultSchema("Diagnosticos");

            // Model Contraints
            ModelConfig(modelBuilder);
        }

        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<DetalleDiagnostico> DetallesDiagnosticos { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            DiagnosticoConfiguration.Configure(modelBuilder.Entity<Diagnostico>());
            DetalleDiagnosticoConfiguration.Configure(modelBuilder.Entity<DetalleDiagnostico>());
        }
    }
}
