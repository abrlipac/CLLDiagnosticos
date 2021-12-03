using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Diagnosticos.Domain
{
    public class Diagnostico
    {
        public int Id { get; set; }
        public int Paciente_Id { get; set; }
        public int Especialidad_Id { get; set; }
        [JsonIgnore]
        public Especialidad Especialidad { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<DetalleDiagnostico> DetallesDiagnostico { get; set; } = new List<DetalleDiagnostico>();
        public ICollection<PosibleEnfermedad> PosiblesEnfermedades { get; set; } = new List<PosibleEnfermedad>();
    }
}
