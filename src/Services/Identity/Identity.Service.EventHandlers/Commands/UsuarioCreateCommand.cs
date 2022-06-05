using Identity.Service.EventHandlers.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Identity.Service.EventHandlers.Commands
{
    public class UsuarioCreateCommand : IRequest<Result>
    {
        [Required]
        [RegularExpression(@"^[A-Za-záéíóúñ]{2,}([\s][A-Za-záéíóúñ]{2,})+$", ErrorMessage = "El nombre no es válido")]
        public string NombreCompleto { get; set; }
        [Required]
        [RegularExpression(@"\w+", ErrorMessage = "El username solo puede contener letras y números")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener un mínimo de 6 caracteres")]
        public string Password { get; set; }
    }
}
