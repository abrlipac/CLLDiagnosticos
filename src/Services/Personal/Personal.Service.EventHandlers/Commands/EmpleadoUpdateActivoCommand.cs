using MediatR;

namespace Personal.Service.EventHandlers.Commands
{
    public class EmpleadoUpdateActivoCommand : INotification
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
    }
}
