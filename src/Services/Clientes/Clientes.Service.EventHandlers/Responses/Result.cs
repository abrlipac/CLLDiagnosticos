using Clientes.Service.EventHandlers.DTOs;

namespace Clientes.Service.EventHandlers.Responses
{
    public class Result
    {
        public bool Succeed { get; set; }
        public PacienteDto Paciente { get; set; }
        public string Error { get; set; }
    }
}