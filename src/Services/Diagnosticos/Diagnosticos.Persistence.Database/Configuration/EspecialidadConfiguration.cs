using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class EspecialidadConfiguration
    {
        public static void Configure(EntityTypeBuilder<Especialidad> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Nombre).HasMaxLength(64).IsRequired();
            entityBuilder.Property(x => x.Descripcion).IsRequired();

            entityBuilder.HasData(
                new Especialidad
                {
                    Id = 1,
                    Nombre = "Pediatría",
                    Descripcion = "Es la rama de la medicina que se especializa en la salud y las enfermedades de los niños. Se trata de una especialidad médica que se centra en los pacientes desde el momento del nacimiento hasta la adolescencia."
                },
                new Especialidad
                {
                    Id = 2,
                    Nombre = "Cardiología",
                    Descripcion = "La cardiología es la rama de la medicina que se encarga del estudio, diagnóstico y tratamiento de las enfermedades del corazón y del aparato circulatorio."
                },
                new Especialidad
                {
                    Id = 3,
                    Nombre = "Gastroenterología",
                    Descripcion = "Es la especialidad médica que se ocupa de las enfermedades del aparato digestivo y órganos asociados, conformado por: esófago, estómago, hígado y vías biliares, páncreas, intestino delgado (duodeno, yeyuno, íleon), colon y recto. El médico que practica esta especialidad se llama gastroenterólogo o especialista en aparato digestivo."
                },
                new Especialidad
                {
                    Id = 4,
                    Nombre = "General",
                    Descripcion = "Por motivos de prueba."
                }
            );
        }
    }
}
