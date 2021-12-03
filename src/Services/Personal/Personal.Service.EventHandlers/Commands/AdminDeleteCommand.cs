using MediatR;

namespace Personal.Service.EventHandlers.Commands
{
    public class AdminDeleteCommand : INotification
    {
        public int Id { get; set; }
    }
}
