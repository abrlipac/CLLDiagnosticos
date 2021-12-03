using MediatR;

namespace Personal.Service.EventHandlers.Commands
{
    public class AdminUpdateActivoCommand : INotification
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
    }
}
