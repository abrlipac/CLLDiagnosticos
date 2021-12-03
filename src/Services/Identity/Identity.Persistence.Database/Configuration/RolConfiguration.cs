using Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Database.Configuration
{
    public static class RolConfiguration
    {
        public const string Admin_Id = "2301D884-221A-4E7D-B509-0113DCC043E1";
        public const string Paciente_Id = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";

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
