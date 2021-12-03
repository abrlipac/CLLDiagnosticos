using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Diagnosticos.Domain
{
    public class Pregunta
    {
        public int Id { get; set; }
        public int Especialidad_Id { get; set; }
        [JsonIgnore]
        public Especialidad Especialidad { get; set; }
        public string Contenido { get; set; }
        public bool TieneOpciones { get; set; }
        public string PalabraClave { get; set; }
        public ICollection<Opcion> Opciones { get; set; }
        public ICollection<DetalleDiagnostico> DetallesDiagnosticos { get; set; }
    }
}
