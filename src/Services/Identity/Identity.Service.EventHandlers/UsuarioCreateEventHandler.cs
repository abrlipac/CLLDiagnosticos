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
        private readonly UserManager<Usuario> UserManager;

        public UsuarioCreateEventHandler(
            UserManager<Usuario> userManager)
        {
            UserManager = userManager;
        }

        public async Task<IdentityResult> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var entry = new Usuario
            {
                NombreCompleto = request.NombreCompleto,
                UserName = request.UserName,
            };

            return await UserManager.CreateAsync(entry, request.Password);
        }
    }
}
