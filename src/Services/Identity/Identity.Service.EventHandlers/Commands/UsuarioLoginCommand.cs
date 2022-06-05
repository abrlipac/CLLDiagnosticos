using Identity.Service.EventHandlers.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Identity.Service.EventHandlers.Commands
{
    public class UsuarioLoginCommand : IRequest<IdentityAccess>
    {
        [Required]
        [RegularExpression(@"\w+", ErrorMessage = "El username solo puede contener letras y números")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener un mínimo de 6 caracteres")]
        public string Password { get; set; }
    }
}
