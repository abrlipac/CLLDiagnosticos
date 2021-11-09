namespace Personal.Service.Queries.DTOs
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Activo { get; set; }
    }
}
