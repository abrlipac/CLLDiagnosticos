using MediatR;
using System.Collections.Generic;

namespace Diagnosticos.Service.EventHandlers.Commands
{
    public class DiagnosticoCreateCommand : INotification
    {
        public int Empleado_Id { get; set; }
        public int Paciente_Id { get; set; }
        public ICollection<DetalleDiagnosticoCreate> DetallesDiagnostico { get; set; } = new List<DetalleDiagnosticoCreate>();
    }

    public class DetalleDiagnosticoCreate
    {
        public string Sintoma { get; set; }
    }
}
