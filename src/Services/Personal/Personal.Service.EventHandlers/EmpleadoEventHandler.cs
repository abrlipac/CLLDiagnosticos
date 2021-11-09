using Personal.Domain;
using Personal.Persistence.Database;
using Personal.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Personal.Service.EventHandlers
{
    public class EmpleadoEventHandler :
        INotificationHandler<EmpleadoCreateCommand>,
        INotificationHandler<EmpleadoUpdateActivoCommand>,
        INotificationHandler<EmpleadoDeleteCommand>
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EmpleadoCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Empleado {
                Dni = notification.Dni,
                Nombres = notification.Nombres,
                Apellidos = notification.Apellidos,
                Activo = notification.Activo
            });

            await _context.SaveChangesAsync();
        }

        public async Task Handle(EmpleadoUpdateActivoCommand notification, CancellationToken cancellationToken)
        {
            var originalEmpleado =
                await _context.Empleados
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Id == notification.Id,
                        cancellationToken: cancellationToken);

            var updatedEmpleado = new Empleado
            {
                Id = originalEmpleado.Id,
                Dni = originalEmpleado.Dni,
                Nombres = originalEmpleado.Nombres,
                Apellidos = originalEmpleado.Apellidos,
                Activo = notification.Activo
            };

            _context.Update(updatedEmpleado);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(EmpleadoDeleteCommand notification, CancellationToken cancellationToken)
        {
            var empleado = await _context.Empleados.SingleAsync(x => x.Id == notification.Id, cancellationToken);
            
            _context.Remove(empleado);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
