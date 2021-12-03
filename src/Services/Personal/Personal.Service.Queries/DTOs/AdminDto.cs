namespace Personal.Service.Queries.DTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Usuario_Id { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Activo { get; set; }
    }
}
