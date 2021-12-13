using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity.Service.EventHandlers.Commands
{
    public class UsuarioAdminCreateCommand : IRequest<IdentityResult>
    {
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
