using Identity.Domain;
using Identity.Persistence.Database;
using Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using Identity.Service.EventHandlers.Responses;

namespace Identity.Service.EventHandlers
{
    public class UsuarioCreateEventHandler : IRequestHandler<UsuarioCreateCommand, Result>
    {
        private readonly UserManager<Usuario> UserManager;
        private readonly ApplicationDbContext _context;

        public UsuarioCreateEventHandler(
            UserManager<Usuario> userManager, ApplicationDbContext applicationDbContext)
        {
            UserManager = userManager;
            _context = applicationDbContext;
        }

        public async Task<Result> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var entry = request.Adapt<Usuario>();

            var identityResult = await UserManager.CreateAsync(entry, request.Password); // creación del usuario y contraseña

            if (!identityResult.Succeeded)
                return GetResult(identityResult);

            var role = _context.Roles.Find(2); // id de rol paciente
            var user = _context.Users.ToList().Where(x => x.UserName.Equals(entry.UserName)).SingleOrDefault();

            RolUsuario rolUsuario = new RolUsuario
            {
                Rol = role,
                Usuario = user
            }; // asignación del rol paciente

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
