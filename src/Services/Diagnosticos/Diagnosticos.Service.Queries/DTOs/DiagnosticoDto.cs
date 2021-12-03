using System;
using System.Collections.Generic;

namespace Diagnosticos.Service.Queries.DTOs
{
    public class DiagnosticoDto
    {
        public int Id { get; set; }
        public int Paciente_Id { get; set; }
        public int Especialidad_Id { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<DetalleDiagnosticoDto> DetallesDiagnostico { get; set; } = new List<DetalleDiagnosticoDto>();
        public ICollection<PosibleEnfermedadDto> PosiblesEnfermedades { get; set; } = new List<PosibleEnfermedadDto>();
    }
}
