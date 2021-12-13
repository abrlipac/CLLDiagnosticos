using MediatR;
using System.Collections.Generic;

namespace Diagnosticos.Service.EventHandlers.Commands
{
    public class DiagnosticoCreateCommand : INotification, IDiagnosticoCommand
    {
        public int Paciente_Id { get; set; }
        public int Especialidad_Id { get; set; }
        public ICollection<DetalleDiagnosticoCommand> DetallesDiagnostico { get => detallesDiagnostico; set => detallesDiagnostico = value; }

        private ICollection<DetalleDiagnosticoCommand> detallesDiagnostico = new List<DetalleDiagnosticoCommand>();
    }
}
