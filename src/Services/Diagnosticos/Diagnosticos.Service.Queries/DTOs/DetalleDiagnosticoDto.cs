using Diagnosticos.Domain;

namespace Diagnosticos.Service.Queries.DTOs
{
    public class DetalleDiagnosticoDto
    {
        public int Id { get; set; }
        public int Pregunta_Id { get; set; }
        public string Respuesta { get; set; }
    }
}
