using Clientes.Common;
using MediatR;
using System;

namespace Clientes.Service.EventHandlers.Commands
{
    public class PacienteCreateCommand : INotification
    {
        public string Dni { get; set; }
        public string Usuario_Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Region { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public bool Activo { get; set; }
    }
}
