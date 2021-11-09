using MediatR;

namespace Clientes.Service.EventHandlers.Commands
{
    public class PacienteUpdateContactInfoCommand : INotification
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}
