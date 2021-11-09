using Identity.Domain;
using Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Service.EventHandlers
{
    public class UsuarioCreateEventHandler : IRequestHandler<UsuarioCreateCommand, IdentityResult>
    {
        private readonly UserManager<Usuario> _userManager;

        public UsuarioCreateEventHandler(
            UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var entry = new Usuario
            {
                Empleado_Id = request.Empleado_Id,
                NombreCompleto = request.NombreCompleto,
                UserName = request.UserName,
            };

            return await _userManager.CreateAsync(entry, request.Password);
        }
    }
}
