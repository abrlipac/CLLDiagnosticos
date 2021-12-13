using System.Collections.Generic;

namespace Api.Gateway.Models.Diagnosticos.Commands
{
    public interface IDiagnosticoCommand
    {
        public ICollection<DetalleDiagnosticoCommand> DetallesDiagnostico { get; set; }
    }
}