namespace Api.Gateway.Models.Diagnosticos.DTOs
{
    public class PosibleEnfermedadDto
    {
        public int Id { get; set; }
        public int Enfermedad_Id { get; set; }
        public decimal Porcentaje { get; set; }
        /*public EnfermedadDto Enfermedad { get; set; }*/
    }
}
