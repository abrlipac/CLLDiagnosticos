using System.Text.Json.Serialization;

namespace Diagnosticos.Domain
{
    public class DetalleDiagnostico
    {
        public int Id { get; set; }
        public int Diagnostico_Id { get; set; }

        [JsonIgnore]
        public Diagnostico Diagnostico { get; set; }
        public int Pregunta_Id { get; set; }

        [JsonIgnore]
        public Pregunta Pregunta { get; set; }

        public string Respuesta { get; set; }
    }
}
