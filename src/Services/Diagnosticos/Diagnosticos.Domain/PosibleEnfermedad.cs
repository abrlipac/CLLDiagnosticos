using System.Text.Json.Serialization;

namespace Diagnosticos.Domain
{
    public class PosibleEnfermedad
    {
        public int Id { get; set; }
        public int Enfermedad_Id { get; set; }
        [JsonIgnore]
        public Enfermedad Enfermedad { get; set; }
        public int Diagnostico_Id { get; set; }
        [JsonIgnore]
        public Diagnostico Diagnostico { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
