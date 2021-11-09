namespace Api.Gateway.Models.Clientes.Commands
{
    public class PacienteUpdateContactInfoCommand
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}
