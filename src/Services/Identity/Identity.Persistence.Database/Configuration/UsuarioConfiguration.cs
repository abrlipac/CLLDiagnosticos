using Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Persistence.Database.Configuration
{
    public static class UsuarioConfiguration
    {
        public static void Configure(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.NombreCompleto).IsRequired().HasMaxLength(255);

            entityBuilder.HasMany(e => e.Roles).WithOne(e => e.Usuario).HasForeignKey(e => e.UserId).IsRequired();
        }
    }
}
