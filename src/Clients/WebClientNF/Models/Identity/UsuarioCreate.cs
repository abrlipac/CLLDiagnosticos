using System.ComponentModel.DataAnnotations;

namespace WebClientNF.Models
{
    public class UsuarioCreate
    {
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}