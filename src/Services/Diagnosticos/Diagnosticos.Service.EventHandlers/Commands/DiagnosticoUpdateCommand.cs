using MediatR;
using System.Collections.Generic;

namespace Diagnosticos.Service.EventHandlers.Commands
{
    public class DiagnosticoUpdateCommand : INotification, IDiagnosticoCommand
    {
        public int Id { get; set; }
        public ICollection<DetalleDiagnosticoCommand> DetallesDiagnostico { get => detallesDiagnostico; set => detallesDiagnostico = value; }

        private ICollection<DetalleDiagnosticoCommand> detallesDiagnostico = new List<DetalleDiagnosticoCommand>();
    }
}
