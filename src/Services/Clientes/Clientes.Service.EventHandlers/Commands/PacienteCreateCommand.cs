using Clientes.Common;
using Clientes.Service.EventHandlers.Responses;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Service.EventHandlers.Commands
{
    public class PacienteCreateCommand : IRequest<Result>
    {
        [Required]
        [StringLength(8)]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Ingrese un DNI válido")]
        public string Dni { get; set; }
        //[RegularExpression(@"(^\{?[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}\}?)$", ErrorMessage = "Ingrese un Id de usuario válido")]
        [Required]
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
