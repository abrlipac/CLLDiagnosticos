using Diagnosticos.Domain;

namespace Diagnosticos.Service.Queries.DTOs
{
    public class PosibleEnfermedadDto
    {
        public int Id { get; set; }
        public int Enfermedad_Id { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
