using Identity.Domain;
using Identity.Persistence.Database;
using Identity.Service.EventHandlers.Commands;
using Identity.Service.EventHandlers.Responses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Service.EventHandlers
{
    public class UsuarioAdminCreateEventHandler : IRequestHandler<UsuarioAdminCreateCommand, Result>
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

        public async Task<Result> Handle(UsuarioAdminCreateCommand request, CancellationToken cancellationToken)
        {
            var entry = request.Adapt<Usuario>();

            var identityResult = await UserManager.CreateAsync(entry, request.Password); // creación del usuario y contraseña

            if (!identityResult.Succeeded) // si no se pudo registrar al usuario
                return GetResult(identityResult);

            var role = _context.Roles.Find(1); // id de rol admin
            var user = _context.Users.ToList().Where(x => x.UserName.Equals(entry.UserName)).SingleOrDefault(); // busca al usuario creado

            RolUsuario rolUsuario = new RolUsuario
            {
                Rol = role,
                Usuario = user
            }; // asignación del rol admin

            await _context.AddAsync(rolUsuario);
            await _context.SaveChangesAsync();

            return GetResult(identityResult);
        }

        private Result GetResult(IdentityResult identityResult)
        => new Result()
        {
            Succeeded = identityResult.Succeeded,
            Errors = identityResult.Errors.Select(x => x.Description).ToList(),
        };
    }
}
