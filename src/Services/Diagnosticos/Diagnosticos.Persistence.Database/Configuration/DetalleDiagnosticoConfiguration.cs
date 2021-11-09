using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class DetalleDiagnosticoConfiguration
    {
        public static void Configure(EntityTypeBuilder<DetalleDiagnostico> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.Diagnostico)
                .WithMany(x => x.DetallesDiagnostico)
                .HasForeignKey(x => x.Diagnostico_Id)
                .IsRequired();
        }
    }
}
