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
    public class UsuarioCreateEventHandler : IRequestHandler<UsuarioCreateCommand, IdentityResult>
    {
        private readonly UserManager<Usuario> UserManager;
        private readonly ApplicationDbContext _context;

        public UsuarioCreateEventHandler(
            UserManager<Usuario> userManager, ApplicationDbContext applicationDbContext)
        {
            UserManager = userManager;
            _context = applicationDbContext;
        }

        public async Task<IdentityResult> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var entry = new Usuario
            {
                NombreCompleto = request.NombreCompleto,
                UserName = request.UserName,
            };

            var identityResult = await UserManager.CreateAsync(entry, request.Password);

            var role = _context.Roles.Find("7D9B7113-A8F8-4035-99A7-A20DD400F6A3");
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
