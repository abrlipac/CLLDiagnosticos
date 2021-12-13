using System.ComponentModel.DataAnnotations;

namespace WebClientNF.Models
{
    public class UsuarioLogin
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}