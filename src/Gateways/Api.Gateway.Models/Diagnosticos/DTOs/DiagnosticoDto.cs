using System;
using System.Collections.Generic;

namespace Api.Gateway.Models.Diagnosticos.DTOs
{
    public class DiagnosticoDto
    {
        public int Id { get; set; }
        public int Empleado_Id { get; set; }
        public int Paciente_Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Enfermedad { get; set; }
        public ICollection<DetalleDiagnosticoDto> DetallesDiagnostico { get; set; } = new List<DetalleDiagnosticoDto>();
    }
}
