using System.Collections.Generic;

namespace Api.Gateway.Models.Diagnosticos.Commands
{
    public class DiagnosticoCreateCommand
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
