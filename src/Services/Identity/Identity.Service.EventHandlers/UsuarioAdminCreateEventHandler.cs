using Identity.Domain;
using Identity.Persistence.Database;
using Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Service.EventHandlers
{
    public class UsuarioAdminCreateEventHandler : IRequestHandler<UsuarioAdminCreateCommand, IdentityResult>
    {
        private readonly UserManager<Usuario> UserManager;
        private readonly ApplicationDbContext _context;

        public UsuarioAdminCreateEventHandler(
            UserManager<Usuario> userManager,
            ApplicationDbContext applicationDbContext)
        {
            UserManager = userManager;
            _context = applicationDbContext;
        }

        public async Task<IdentityResult> Handle(UsuarioAdminCreateCommand request, CancellationToken cancellationToken)
        {
            var entry = new Usuario
            {
                NombreCompleto = request.NombreCompleto,
                UserName = request.UserName,
            };

            var identityResult = await UserManager.CreateAsync(entry, request.Password);

            var role = _context.Roles.Find("2301D884-221A-4E7D-B509-0113DCC043E1");
            var user = _context.Users.ToList().Where(x => x.UserName.Equals(entry.UserName)).SingleOrDefault();

            RolUsuario rolUsuario = new RolUsuario
            {
                Rol = role,
                Usuario = user
            };

            await _context.AddAsync(rolUsuario);
            await _context.SaveChangesAsync();

            return identityResult;
        }
    }
}
