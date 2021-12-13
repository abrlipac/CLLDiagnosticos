using System.Collections.Generic;

namespace Diagnosticos.Service.Queries.DTOs
{
    public class PreguntaDto
    {
        public int Id { get; set; }
        public int Especialidad_Id { get; set; }
        public string Contenido { get; set; }
        public bool TieneOpciones { get; set; }
        public string PalabraClave { get; set; }
        public ICollection<OpcionDto> Opciones { get; set; } = new List<OpcionDto>();
    }
}
