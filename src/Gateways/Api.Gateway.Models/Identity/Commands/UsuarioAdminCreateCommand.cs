namespace Api.Gateway.Models.Identity.Commands
{
    public class UsuarioAdminCreateCommand
    {
        public string NombreCompleto { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
