namespace Api.Gateway.Models.Personal.Commands
{
    public class EmpleadoCreateCommand
    {
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Activo { get; set; }
    }
}
