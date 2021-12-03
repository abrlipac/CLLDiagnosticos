using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class EnfermedadConfiguration
    {
        public static void Configure(EntityTypeBuilder<Enfermedad> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Nombre).HasMaxLength(64).IsRequired();
            entityBuilder.Property(x => x.Descripcion).HasMaxLength(255).IsRequired();

            entityBuilder.HasData(
                new Enfermedad
                {
                    Id = 1,
                    Nombre = "Gripe",
                    NombreClave = "gripe",
                    Descripcion = "Infección viral común que puede ser mortal, especialmente en grupos de alto riesgo.",
                    Tratamiento = "La gripe se trata principalmente con descanso y líquidos para que el cuerpo pueda combatir la infección por sí solo. Los analgésicos antiinflamatorios de venta libre pueden ayudar con los síntomas. Una vacuna anual puede prevenir la gripe y limitar sus complicaciones.",
                    CantidadSintomas = 5
                },
                new Enfermedad
                {
                    Id = 2,
                    Nombre = "Gripe A",
                    NombreClave = "gripeA",
                    Descripcion = "Es una enfermedad infecciosa causada por un virus de la influenza tipo A. Su morbilidad suele ser alta y su mortalidad baja.",
                    Tratamiento = "Se recomienda el uso de oseltamivir o zanamivir para la prevención y el tratamiento de la infección por los virus de la influenza porcina",
                    CantidadSintomas = 6
                },
                new Enfermedad
                {
                    Id = 3,
                    Nombre = "Anemia",
                    NombreClave = "anemia",
                    Descripcion = "Insuficiencia de glóbulos rojos saludables debido a la falta de hierro en el cuerpo.",
                    Tratamiento = "Utilizar factores de crecimiento como la eritropoyetina permite tratar con gran eficacia muchas formas de anemia. En caso de riesgo de vida, son importantes las transfusiones de concentrados de hematíes provenientes de donaciones.",
                    CantidadSintomas = 5
                },
                new Enfermedad
                {
                    Id = 4,
                    Nombre = "Rubéola",
                    NombreClave = "rubeola",
                    Descripcion = "Infección viral contagiosa que se puede prevenir con una vacuna y es conocida por su característico sarpullido rojo.",
                    Tratamiento = "Si bien no hay ningún tratamiento para eliminar una infección establecida, los medicamentos pueden contrarrestar los síntomas. La vacunación puede ayudar a prevenir la enfermedad.",
                    CantidadSintomas = 4
                },
                new Enfermedad
                {
                    Id = 5,
                    Nombre = "Dengue",
                    NombreClave = "dengue",
                    Descripcion = "Enfermedad viral transmitida por los mosquitos y de prevalencia en las áreas tropicales y subtropicales.",
                    Tratamiento = "El tratamiento incluye la ingesta de líquidos y el uso de analgésicos. Los casos más graves requieren atención hospitalaria.",
                    CantidadSintomas = 5
                },
                new Enfermedad
                {
                    Id = 6,
                    Nombre = "Neumonía",
                    NombreClave = "neumonia",
                    Descripcion = "Infección que inflama los sacos de aire de uno o ambos pulmones, los que pueden llenarse de fluido.",
                    Tratamiento = "Los antibióticos permiten tratar varios tipos de neumonía y algunos pueden prevenirse mediante vacunas.",
                    CantidadSintomas = 4
                },
                new Enfermedad
                {
                    Id = 7,
                    Nombre = "COVID‑19",
                    NombreClave = "covid",
                    Descripcion = "La enfermedad por coronavirus (COVID‑19) es una enfermedad infecciosa provocada por el virus SARS-CoV-2.",
                    Tratamiento = "Para proporcionar unos cuidados óptimos, se necesita oxígeno para los pacientes que se encuentran más graves; en pacientes críticos, se requieren respiradores.",
                    CantidadSintomas = 7
                }
            );
        }
    }
}
