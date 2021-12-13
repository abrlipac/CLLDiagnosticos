using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class OpcionConfiguration
    {
        public static void Configure(EntityTypeBuilder<Opcion> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Valor).HasMaxLength(64).IsRequired();
            entityBuilder.HasOne(x => x.Pregunta)
                .WithMany(x => x.Opciones)
                .HasForeignKey(x => x.Pregunta_Id)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            var opciones = new List<Opcion>();

            for (int i = 1; i <= 21; i++)
            {
                opciones.Add(new Opcion
                {
                    Id = i * 2 - 1,
                    Pregunta_Id = i,
                    Valor = "Sí"
                });
                opciones.Add(new Opcion
                {
                    Id = i * 2,
                    Pregunta_Id = i,
                    Valor = "No"
                });
            }

            entityBuilder.HasData(opciones);
        }
    }
}
