using Personal.Domain;
using Personal.Persistence.Database;
using Personal.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Personal.Service.EventHandlers
{
    public class AdminEventHandler :
        INotificationHandler<AdminCreateCommand>,
        INotificationHandler<AdminUpdateActivoCommand>,
        INotificationHandler<AdminDeleteCommand>
    {
        private readonly ApplicationDbContext Context;

        public AdminEventHandler(
            ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task Handle(AdminCreateCommand notification, CancellationToken cancellationToken)
        {
            await Context.AddAsync(
                new Admin
                {
                    Usuario_Id = notification.Usuario_Id,
                    Dni = notification.Dni,
                    Nombres = notification.Nombres,
                    Apellidos = notification.Apellidos,
                    Activo = notification.Activo
                }, cancellationToken);

            await Context.SaveChangesAsync();
        }

        public async Task Handle(AdminUpdateActivoCommand notification, CancellationToken cancellationToken)
        {
            var originalAdministrador =
                await Context.Administradores
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Id == notification.Id,
                        cancellationToken: cancellationToken);

            var updatedEmpleado = new Admin
            {
                Id = originalAdministrador.Id,
                Usuario_Id = originalAdministrador.Usuario_Id,
                Dni = originalAdministrador.Dni,
                Nombres = originalAdministrador.Nombres,
                Apellidos = originalAdministrador.Apellidos,
                Activo = notification.Activo
            };

            Context.Update(updatedEmpleado);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(AdminDeleteCommand notification, CancellationToken cancellationToken)
        {
            var empleado = await Context.Administradores
                .SingleAsync(x => x.Id == notification.Id, cancellationToken);

            Context.Remove(empleado);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
