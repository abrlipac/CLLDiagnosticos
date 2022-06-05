using System.Collections.Generic;

namespace Diagnosticos.Service.Queries.DTOs
{
    public class ResultadoDiagnosticoDto
    {
        public int Id { get; set; }
        public int Paciente_Id { get; set; }
        public ICollection<PosibleEnfermedadDto> PosiblesEnfermedades { get; set; } = new List<PosibleEnfermedadDto>();
    }
}
