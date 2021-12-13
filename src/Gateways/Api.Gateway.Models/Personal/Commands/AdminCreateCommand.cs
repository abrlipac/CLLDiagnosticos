namespace Api.Gateway.Models.Personal.Commands
{
    public class AdminCreateCommand
    {
        public string Usuario_Id { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Activo { get; set; }
    }
}
