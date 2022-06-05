using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diagnosticos.Service.EventHandlers.Commands
{
    public class DiagnosticoCreateCommand : INotification, IDiagnosticoCommand
    {
        [Required]
        public int Paciente_Id { get; set; }
        [Required]
        public int Especialidad_Id { get; set; }
        public ICollection<DetalleDiagnosticoCommand> DetallesDiagnostico { get => detallesDiagnostico; set => detallesDiagnostico = value; }

        private ICollection<DetalleDiagnosticoCommand> detallesDiagnostico = new List<DetalleDiagnosticoCommand>();
    }
}
