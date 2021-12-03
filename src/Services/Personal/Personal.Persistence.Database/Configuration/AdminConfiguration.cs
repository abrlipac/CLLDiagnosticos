using Personal.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Personal.Persistence.Database.Configuration
{
    public static class AdminConfiguration
    {
        public static void Configure(EntityTypeBuilder<Admin> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => x.Usuario_Id).IsUnique();
            entityBuilder.HasIndex(x => x.Dni).IsUnique();
            entityBuilder.Property(x => x.Dni).IsRequired().HasMaxLength(8);
            entityBuilder.Property(x => x.Nombres).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Apellidos).IsRequired().HasMaxLength(255);

            var dniNum = 76368626;
            var administradores = new List<Admin>();

            for (var i = 1; i <= 10; i++)
            {
                administradores.Add(new Admin
                {
                    Id = i,
                    Usuario_Id = i.ToString(),
                    Dni = dniNum++.ToString(),
                    Nombres = $"Nombres {i}",
                    Apellidos = $"Apellidos {i}",
                    Activo = true
                });
            }

            entityBuilder.HasData(administradores);
        }
    }
}
