using Microsoft.EntityFrameworkCore;
using Diagnosticos.Domain;
using Diagnosticos.Persistence.Database.Configuration;

namespace Diagnosticos.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Database schema
            modelBuilder.HasDefaultSchema("Diagnosticos");

            // Model Contraints
            ModelConfig(modelBuilder);
        }

        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Enfermedad> Enfermedades { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
        public DbSet<DetalleDiagnostico> DetallesDiagnosticos { get; set; }
        public DbSet<PosibleEnfermedad> PosiblesEnfermedades { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            EspecialidadConfiguration.Configure(modelBuilder.Entity<Especialidad>());
            EnfermedadConfiguration.Configure(modelBuilder.Entity<Enfermedad>());
            DetalleDiagnosticoConfiguration.Configure(modelBuilder.Entity<DetalleDiagnostico>());
            DiagnosticoConfiguration.Configure(modelBuilder.Entity<Diagnostico>());
            OpcionConfiguration.Configure(modelBuilder.Entity<Opcion>());
            PosibleEnfermedadConfiguration.Configure(modelBuilder.Entity<PosibleEnfermedad>());
            PreguntaConfiguration.Configure(modelBuilder.Entity<Pregunta>());
        }
    }
}
