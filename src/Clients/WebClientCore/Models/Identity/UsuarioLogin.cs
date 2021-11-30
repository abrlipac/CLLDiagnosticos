using System.ComponentModel.DataAnnotations;

namespace WebClientCore.Models
{
    public class UsuarioLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}