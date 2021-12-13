using System.Collections.Generic;

namespace Diagnosticos.Service.EventHandlers.Commands
{
    public interface IDiagnosticoCommand
    {
        public ICollection<DetalleDiagnosticoCommand> DetallesDiagnostico { get; set; }
    }
}