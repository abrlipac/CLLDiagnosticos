using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Clientes.Domain;
using Clientes.Common;

namespace Clientes.Persistence.Database.Configuration
{
    public static class PacienteConfiguration
    {
        public static void Configure(EntityTypeBuilder<Paciente> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Dni).IsRequired().HasMaxLength(8);
            entityBuilder.Property(x => x.Nombres).IsRequired();
            entityBuilder.Property(x => x.Apellidos).IsRequired();
            entityBuilder.Property(x => x.Celular).HasMaxLength(12);

            var dniNum = 76368636;
            var celularNum = 51942024657;
            var pacientes = new List<Paciente>();

            for (var i = 1; i <= 100; i++)
            {
                pacientes.Add(new Paciente
                {
                    Id = i,
                    Dni = dniNum++.ToString(),
                    Nombres = $"Nombre {i}",
                    Apellidos = $"Apellido {i}",
                    Activo = true,
                    Sexo = i % 2 == 0 ? Sexo.Masculino : Sexo.Femenino,
                    Email = $"paciente{i}@gmail.com",
                    Celular = $"+{celularNum++}"
                });
            }

            entityBuilder.HasData(pacientes);
        }
    }
}
