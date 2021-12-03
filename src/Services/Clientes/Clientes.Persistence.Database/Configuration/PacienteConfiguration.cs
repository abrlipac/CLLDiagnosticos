using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Clientes.Domain;
using Clientes.Common;
using System;

namespace Clientes.Persistence.Database.Configuration
{
    public static class PacienteConfiguration
    {
        public static void Configure(EntityTypeBuilder<Paciente> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(x => x.Usuario_Id).IsUnique();
            entityBuilder.HasIndex(x => x.Dni).IsUnique();
            entityBuilder.Property(x => x.Dni).IsRequired().HasMaxLength(8);
            entityBuilder.Property(x => x.Nombres).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Apellidos).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Celular).IsRequired().HasMaxLength(9);
            entityBuilder.Property(x => x.Region).IsRequired().HasMaxLength(64);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(128);

            var dniNum = 76368636;
            var celularNum = 942024657;
            var pacientes = new List<Paciente>();
            var año = 2003;
            var usuario_Id = 11;

            for (var i = 1; i <= 100; i++)
            {
                pacientes.Add(new Paciente
                {
                    Id = i,
                    Usuario_Id = usuario_Id++.ToString(),
                    Dni = dniNum++.ToString(),
                    Nombres = $"Nombre {i}",
                    Apellidos = $"Apellido {i}",
                    Activo = true,
                    Sexo = i % 2 == 0 ? Sexo.Masculino : Sexo.Femenino,
                    Email = $"paciente{i}@gmail.com",
                    Celular = celularNum++.ToString(),
                    FechaNacimiento = new DateTime(año--, 10, 21),
                    Region = i % 6 == 0 ? "Puno"
                        : i % 10 == 0 ? "Arequipa"
                        : "Tacna"
                });
            }

            entityBuilder.HasData(pacientes);
        }
    }
}
