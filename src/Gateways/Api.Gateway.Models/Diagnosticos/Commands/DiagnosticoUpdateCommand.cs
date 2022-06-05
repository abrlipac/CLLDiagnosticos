using System.Collections.Generic;

namespace Api.Gateway.Models.Diagnosticos.Commands
{
    public class DiagnosticoUpdateCommand
    {
        public int Id { get; set; }
        public ICollection<DetalleDiagnosticoCommand> DetallesDiagnostico { get => detallesDiagnostico; set => detallesDiagnostico = value; }
        private ICollection<DetalleDiagnosticoCommand> detallesDiagnostico = new List<DetalleDiagnosticoCommand>();
    }
}
