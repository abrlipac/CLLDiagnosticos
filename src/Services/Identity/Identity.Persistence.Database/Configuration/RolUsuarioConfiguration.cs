using Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Identity.Persistence.Database.Configuration
{
    public static class RolUsuarioConfiguration
    {
        public static void Configure(EntityTypeBuilder<RolUsuario> entityBuilder)
        {
            var rolesUsuario = new List<RolUsuario>();

            for (var i = 1; i <= 110; i++)
            {
                rolesUsuario.Add(new RolUsuario
                {
                    UserId = i,
                    RoleId = i <= 10 ? RolConfiguration.Admin_Id : RolConfiguration.Paciente_Id
                });
            }

            entityBuilder.HasData(rolesUsuario);
        }
    }
}
