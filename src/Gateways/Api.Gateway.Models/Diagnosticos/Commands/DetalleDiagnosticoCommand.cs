using System.ComponentModel.DataAnnotations;

namespace Api.Gateway.Models.Diagnosticos.Commands
{
    public class DetalleDiagnosticoCommand
    {
        public int Pregunta_Id { get; set; }
        public string Respuesta { get; set; }
    }
}
