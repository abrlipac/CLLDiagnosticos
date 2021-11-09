using System;
using System.Collections.Generic;

namespace Diagnosticos.Domain
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public int Empleado_Id { get; set; }
        public int Paciente_Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Enfermedad { get; set; }
        public ICollection<DetalleDiagnostico> DetallesDiagnostico { get; set; } = new List<DetalleDiagnostico>();
    }
}
