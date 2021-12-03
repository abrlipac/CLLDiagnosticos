using MediatR;
using System.Collections.Generic;

namespace Diagnosticos.Service.EventHandlers.Commands
{
    public class DiagnosticoCreateCommand : INotification
    {
        public int Paciente_Id { get; set; }
        public int Especialidad_Id { get; set; }
        public ICollection<DetalleDiagnosticoCreate> DetallesDiagnostico { get; set; } = new List<DetalleDiagnosticoCreate>();
    }

    public class DetalleDiagnosticoCreate
    {
        public int Pregunta_Id { get; set; }
        public string Respuesta { get; set; }
    }
}
