using System;
using System.Collections.Generic;

namespace Api.Gateway.Models.Diagnosticos.DTOs
{
    public class EnfermedadDiagnosticoDto
    {
        public int Id { get; set; }
        public int Paciente_Id { get; set; }
        public int Especialidad_Id { get; set; }
        public int Enfermedad_Id { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<PosibleEnfermedadDto> PosiblesEnfermedades { get; set; } = new List<PosibleEnfermedadDto>();
        public string Enfermedad_Nombre { get; set; }
    }
}
