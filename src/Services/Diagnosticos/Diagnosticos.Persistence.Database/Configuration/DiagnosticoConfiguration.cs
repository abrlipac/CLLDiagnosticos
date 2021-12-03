using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class DiagnosticoConfiguration
    {
        public static void Configure(EntityTypeBuilder<Diagnostico> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.Especialidad)
                .WithMany(x => x.Diagnosticos)
                .HasForeignKey(x => x.Especialidad_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
