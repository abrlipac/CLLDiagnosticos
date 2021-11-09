using System.ComponentModel.DataAnnotations;

namespace Api.Gateway.Models.Identity.Commands
{
    public class UsuarioCreateCommand
    {
        [Required]
        public int Empleado_Id { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
