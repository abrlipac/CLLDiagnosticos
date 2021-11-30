using System.ComponentModel.DataAnnotations;

namespace WebClientCore.Models
{
    public class UsuarioCreate
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
