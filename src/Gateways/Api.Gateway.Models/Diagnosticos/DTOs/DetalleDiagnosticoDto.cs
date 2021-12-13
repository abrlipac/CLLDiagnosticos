namespace Api.Gateway.Models.Diagnosticos.DTOs
{
    public class DetalleDiagnosticoDto
    {
        public int Id { get; set; }
        public int Pregunta_Id { get; set; }
        public string Respuesta { get; set; }
    }
}
