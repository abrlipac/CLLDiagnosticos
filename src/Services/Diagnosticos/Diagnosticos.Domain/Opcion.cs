using System.Text.Json.Serialization;

namespace Diagnosticos.Domain
{
    public class Opcion
    {
        public int Id { get; set; }
        public int Pregunta_Id { get; set; }
        [JsonIgnore]
        public Pregunta Pregunta { get; set; }
        public string Valor { get; set; }

    }
}
