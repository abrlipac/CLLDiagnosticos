using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diagnosticos.Service.EventHandlers.Commands
{
    public class DiagnosticoUpdateCommand : INotification, IDiagnosticoCommand
    {
        [Required]
        public int Id { get; set; }
        public ICollection<DetalleDiagnosticoCommand> DetallesDiagnostico { get => detallesDiagnostico; set => detallesDiagnostico = value; }

        private ICollection<DetalleDiagnosticoCommand> detallesDiagnostico = new List<DetalleDiagnosticoCommand>();
    }
}
