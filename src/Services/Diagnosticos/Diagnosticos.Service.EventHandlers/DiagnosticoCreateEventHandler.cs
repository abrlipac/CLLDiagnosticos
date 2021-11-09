using MediatR;
using Microsoft.Extensions.Logging;
using Diagnosticos.Domain;
using Diagnosticos.Persistence.Database;
using Diagnosticos.Service.EventHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Prolog;
using Diagnosticos.Service.EventHandlers.Exceptions;
using System.IO;

namespace Diagnosticos.Service.EventHandlers
{
    public class DiagnosticoCreateEventHandler :
        INotificationHandler<DiagnosticoCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DiagnosticoCreateEventHandler> _logger;

        public static readonly bool IsRunningFromUnitTest =
            AppDomain.CurrentDomain.GetAssemblies().Any(
                a => a.FullName.ToLowerInvariant().Contains("unit") ||
                    a.FullName.ToLowerInvariant().Contains("test"));

        public DiagnosticoCreateEventHandler(
            ApplicationDbContext context,
            ILogger<DiagnosticoCreateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(DiagnosticoCreateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("! Empezó la creación de un nuevo diagnóstico");
            var entry = new Diagnostico();

            using (var transaction = await _context.Database.BeginTransactionAsync()) 
            {
                _logger.LogInformation("! Preparando los detalles");
                PrepareDetails(entry, notification);

                _logger.LogInformation("! Preparando la cabecera");
                PrepareHeader(entry, notification);

                _logger.LogInformation("! Guardando el diagnóstico");
                await _context.AddAsync(entry);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"! El diagnóstico ha sido creado");

                await transaction.CommitAsync();
            }

            _logger.LogInformation("! Terminó la creación de un nuevo diagnóstico");
        }

        private void PrepareDetails(Diagnostico entry, DiagnosticoCreateCommand notification) 
        {
            entry.DetallesDiagnostico = notification.DetallesDiagnostico.Select(x => new DetalleDiagnostico
            {
                Diagnostico_Id = entry.Id,
                Sintoma = x.Sintoma
            }).ToList();
        }

        private void PrepareHeader(Diagnostico entry, DiagnosticoCreateCommand notification)
        {
            // Header information
            entry.Enfermedad = DeterminarEnfermedad(notification);
            entry.Fecha = DateTime.UtcNow;
            entry.Paciente_Id = notification.Paciente_Id;
            entry.Empleado_Id = notification.Empleado_Id;
        }

        public string DeterminarEnfermedad(DiagnosticoCreateCommand notification)
        {
            var prolog = new PrologEngine(persistentCommandHistory: false);
            string absPath;

            var filename = "enfermedad.pl";
            
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "production")
                absPath = Path.GetFullPath($"./pl/{filename}");
            else if (!IsRunningFromUnitTest)
                absPath = Path.GetFullPath($"./../Diagnosticos.Service.EventHandlers/{filename}");
            else
                absPath = Path.GetFullPath($"./../../../../Diagnosticos.Service.EventHandlers/{filename}");

            _logger.LogInformation($"Ruta del archivo: {absPath}");

            var enfermedades = new List<Enfermedad>
            {
                new Enfermedad { Nombre = "gripe", Cantidad = 0, Porcentaje = 0, CantSintomas = 5d },
                new Enfermedad { Nombre = "gripeA", Cantidad = 0, Porcentaje = 0, CantSintomas = 6d },
                new Enfermedad { Nombre = "anemia", Cantidad = 0, Porcentaje = 0, CantSintomas = 5d },
                new Enfermedad { Nombre = "rubeola", Cantidad = 0, Porcentaje = 0, CantSintomas = 4d },
                new Enfermedad { Nombre = "dengue", Cantidad = 0, Porcentaje = 0, CantSintomas = 5d },
                new Enfermedad { Nombre = "neumonia", Cantidad = 0, Porcentaje = 0, CantSintomas = 4d },
                new Enfermedad { Nombre = "covid", Cantidad = 0, Porcentaje = 0, CantSintomas = 7d }
            };

            if (notification.DetallesDiagnostico == null || notification.DetallesDiagnostico.Count <= 0)
                throw new DiagnosticosDiagnosticoCreateCommandException($"No hay detalles de diagnostico en el diagnostico.");

            foreach (var detalle in notification.DetallesDiagnostico)
            {
                var solution = prolog
                    .GetAllSolutions(absPath, $"enfermedadde(Z, {detalle.Sintoma})")
                    .NextSolution;

                foreach (var variable in solution)
                {
                    var coincidencia = variable.NextVariable.First().Value;

                    if (enfermedades.Select(x => x.Nombre).Contains(coincidencia))
                        enfermedades.Single(x => x.Nombre == coincidencia).Cantidad++;
                }
            }

            foreach (var enfermedad in enfermedades)
                enfermedad.Porcentaje = enfermedad.Cantidad * 100 / enfermedad.CantSintomas;

            var maxPorc = enfermedades.Max(x => x.Porcentaje);

            if(maxPorc <= 0)
                throw new DiagnosticosDiagnosticoCreateCommandException($"No hay detalles de diagnostico con sintomas predefinidos en el diagnostico");

            return enfermedades.First(x => x.Porcentaje == maxPorc).Nombre;
        }

        class Enfermedad
        {
            public string Nombre;
            public int Cantidad;
            public double Porcentaje;
            public double CantSintomas;
        }
    }
}
