using Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Database.Configuration
{
    public static class RolConfiguration
    {
        public const int Admin_Id = 1;
        public const int Paciente_Id = 2;

        public static void Configure(EntityTypeBuilder<Rol> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasMany(e => e.RolesUsuario).WithOne(e => e.Rol).HasForeignKey(e => e.RoleId).IsRequired();

            entityBuilder.HasData(
                new Rol
                {
                    Id = Admin_Id,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Rol
                {
                    Id = Paciente_Id,
                    Name = "Paciente",
                    NormalizedName = "PACIENTE"
                }
            );
        }
    }
}
