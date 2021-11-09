using Personal.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Personal.Persistence.Database.Configuration
{
    public static class EmpleadoConfiguration
    {
        public static void Configure(EntityTypeBuilder<Empleado> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Dni).IsRequired().HasMaxLength(8);
            entityBuilder.Property(x => x.Nombres).IsRequired();
            entityBuilder.Property(x => x.Apellidos).IsRequired();

            var dniNum = 76368626;
            var empleados = new List<Empleado>();

            for (var i = 1; i <= 10; i++)
            {
                empleados.Add(new Empleado
                {
                    Id = i,
                    Dni = dniNum++.ToString(),
                    Nombres = $"Nombre {i}",
                    Apellidos = $"Apellido {i}",
                    Activo = true
                });
            }

            entityBuilder.HasData(empleados);
        }
    }
}
