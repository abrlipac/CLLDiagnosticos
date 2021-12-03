using Diagnosticos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diagnosticos.Persistence.Database.Configuration
{
    public static class PreguntaConfiguration
    {
        public static void Configure(EntityTypeBuilder<Pregunta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Contenido).HasMaxLength(255).IsRequired();
            entityBuilder.HasOne(x => x.Especialidad)
                .WithMany(x => x.Preguntas)
                .HasForeignKey(x => x.Especialidad_Id)
                .IsRequired();

            entityBuilder.HasData(
                new Pregunta
                {
                    Id = 1,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene una sensación de temperatura alta en el cuerpo?",
                    PalabraClave = "fiebre",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 2,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene una sensación generalizada de molestia?",
                    PalabraClave = "malestargeneral",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 3,
                    Especialidad_Id = 4,
                    Contenido = "¿Sufre de dolor de garganta?",
                    PalabraClave = "dolorgarganta",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 4,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene dolor de cabeza? (ya sea, leve o moderado)",
                    PalabraClave = "dolorcabeza",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 5,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene la nariz tapada (congestionada)?",
                    PalabraClave = "congestionnasal",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 6,
                    Especialidad_Id = 4,
                    Contenido = "¿Sufre de tos con flema?",
                    PalabraClave = "tos",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 7,
                    Especialidad_Id = 4,
                    Contenido = "¿Sufre de dolor y malestar en los músculos (ya sea, moderado o intenso)?",
                    PalabraClave = "dolormuscular",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 8,
                    Especialidad_Id = 4,
                    Contenido = "¿No tuvo apetito en los últimos 2 días?",
                    PalabraClave = "perdidaapetito",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 9,
                    Especialidad_Id = 4,
                    Contenido = "¿Ha sufrido de nauseas en las últimas 24 horas?",
                    PalabraClave = "nauseas",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 10,
                    Especialidad_Id = 4,
                    Contenido = "¿Ha vomitado en las últimas horas?",
                    PalabraClave = "vomito",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 11,
                    Especialidad_Id = 4,
                    Contenido = "¿Se siente cansado y sin ganas de hacer nada?",
                    PalabraClave = "cansancio",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 12,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene dificultad para respirar adecuadamente?",
                    PalabraClave = "dificultadrespirar",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 13,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene una sensación de tener frío y temblores a pesar de no estar en un lugar frío?",
                    PalabraClave = "escalofrios",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 14,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene los ojos más rojos de lo habitual?",
                    PalabraClave = "ojosrojos",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 15,
                    Especialidad_Id = 4,
                    Contenido = "¿Sufre de brotes temporales de parches de piel enrojecidos, bultos, escamas y picazón?",
                    PalabraClave = "erupcionespiel",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 16,
                    Especialidad_Id = 4,
                    Contenido = "¿Sufre de dolor en las articulaciones?",
                    PalabraClave = "dolorarticulacion",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 17,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene malestar, dolor leve, ardor o agobio en el pecho?",
                    PalabraClave = "dolorpecho",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 18,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene tos que regresa constanmente cada pocos minutos?",
                    PalabraClave = "tosconstante",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 19,
                    Especialidad_Id = 4,
                    Contenido = "¿Tiene una temperatura corporal muy alta con escalofríos constantes?",
                    PalabraClave = "fiebreescalofrios",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 20,
                    Especialidad_Id = 4,
                    Contenido = "¿Ha perdido sensibilidad en el gusto y no siente olores a su alrededor?",
                    PalabraClave = "perdidagustoolfato",
                    TieneOpciones = true
                },
                new Pregunta
                {
                    Id = 21,
                    Especialidad_Id = 4,
                    Contenido = "¿Sufre de tos sin flema (tos seca)?",
                    PalabraClave = "tosseca",
                    TieneOpciones = true
                }
                );
        }
    }
}
