using Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Identity.Persistence.Database.Configuration
{
    public static class RolConfiguration
    {
        public static void Configure(EntityTypeBuilder<Rol> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.HasData(
                new Rol
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            entityBuilder.HasMany(e => e.RolesUsuario).WithOne(e => e.Rol).HasForeignKey(e => e.RoleId).IsRequired();
        }
    }
}
