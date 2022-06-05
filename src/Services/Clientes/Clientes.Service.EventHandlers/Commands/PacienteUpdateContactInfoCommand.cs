using Clientes.Service.EventHandlers.Responses;
using MediatR;

namespace Clientes.Service.EventHandlers.Commands
{
    public class PacienteUpdateContactInfoCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}
