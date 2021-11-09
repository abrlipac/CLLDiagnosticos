using MediatR;

namespace Personal.Service.EventHandlers.Commands
{
    public class EmpleadoDeleteCommand : INotification
    {
        public int Id { get; set; }
    }
}
