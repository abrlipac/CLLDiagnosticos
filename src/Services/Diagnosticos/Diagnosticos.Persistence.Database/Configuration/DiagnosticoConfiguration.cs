using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class DiagnosticoConfiguration
    {
        public static void Configure(EntityTypeBuilder<Diagnostico> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
