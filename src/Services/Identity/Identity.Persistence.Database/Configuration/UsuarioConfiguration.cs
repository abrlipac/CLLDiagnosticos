using Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Identity.Persistence.Database.Configuration
{
    public static class UsuarioConfiguration
    {
        public static void Configure(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.NombreCompleto).IsRequired().HasMaxLength(255);
            entityBuilder.HasMany(e => e.Roles).WithOne(e => e.Usuario).HasForeignKey(e => e.UserId).IsRequired();

            var usuarios = new List<Usuario>();

            for (var i = 1; i <= 110; i++)
            {
                var usuario = new Usuario
                {
                    Id = i,
                    NombreCompleto = i <= 10 ? $"Nombres {i} Apellidos {i}"
                        : $"Nombres {i - 10} Apellidos {i - 10}",
                    UserName = i <= 10 ? $"admin{i}" : $"paciente{i - 10}",
                    NormalizedUserName = i <= 10 ? $"ADMIN{i}" : $"PACIENTE{i - 10}",
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                };
                usuario.PasswordHash = GeneratePass(usuario);
                usuarios.Add(usuario);
            }

            entityBuilder.HasData(usuarios);
        }

        public static string GeneratePass(Usuario usuario)
        {
            var passHash = new PasswordHasher<Usuario>();
            return passHash.HashPassword(usuario, "123456");
        }
    }
}
