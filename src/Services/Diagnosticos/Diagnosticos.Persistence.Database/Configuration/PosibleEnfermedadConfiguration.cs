using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class PosibleEnfermedadConfiguration
    {
        public static void Configure(EntityTypeBuilder<PosibleEnfermedad> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Porcentaje).HasPrecision(4, 1);
            entityBuilder.HasOne(x => x.Diagnostico)
                .WithMany(x => x.PosiblesEnfermedades)
                .HasForeignKey(x => x.Diagnostico_Id)
                .IsRequired();
            entityBuilder.HasOne(x => x.Enfermedad)
                .WithMany(x => x.PosiblesEnfermedades)
                .HasForeignKey(x => x.Enfermedad_Id)
                .IsRequired();
        }
    }
}
