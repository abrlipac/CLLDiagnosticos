using System.ComponentModel.DataAnnotations;

namespace Models.Identity.Commands
{
    public class UsuarioLoginCommand
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
