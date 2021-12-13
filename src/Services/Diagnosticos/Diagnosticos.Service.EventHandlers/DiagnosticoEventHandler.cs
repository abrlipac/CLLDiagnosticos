using Diagnosticos.Domain;
using Diagnosticos.Persistence.Database;
using Diagnosticos.Service.EventHandlers.Commands;
using Diagnosticos.Service.EventHandlers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prolog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Diagnosticos.Service.EventHandlers
{
    public class DiagnosticoEventHandler :
        INotificationHandler<DiagnosticoCreateCommand>,
        INotificationHandler<DiagnosticoUpdateCommand>
    {
        private readonly ApplicationDbContext Context;
        private readonly ILogger<DiagnosticoEventHandler> Logger;

        public static readonly bool IsRunningFromUnitTest =
            AppDomain.CurrentDomain.GetAssemblies().Any(
                a => a.FullName.ToLowerInvariant().Contains("unit") ||
                    a.FullName.ToLowerInvariant().Contains("test"));

        public DiagnosticoEventHandler(
            ApplicationDbContext context,
            ILogger<DiagnosticoEventHandler> logger)
        {
            Context = context;
            Logger = logger;
        }

        public async Task Handle(DiagnosticoCreateCommand notification, CancellationToken cancellationToken)
        {
            Logger.LogInformation("! Empezó la creación de un nuevo diagnóstico");
            var entry = new Diagnostico();

            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                Logger.LogInformation("! Preparando los detalles");
                PrepareDetails(entry, notification);

                Logger.LogInformation("! Preparando los resultados");
                PrepareEnfermedades(entry, notification);

                Logger.LogInformation("! Preparando la cabecera");
                PrepareHeader(entry, notification);

                Logger.LogInformation("! Guardando el diagnóstico");
                await Context.AddAsync(entry);
                await Context.SaveChangesAsync();

                Logger.LogInformation($"! El diagnóstico ha sido creado");

                await transaction.CommitAsync();
            }

            Logger.LogInformation("! Terminó la creación de un nuevo diagnóstico");
        }

        public async Task Handle(DiagnosticoUpdateCommand notification, CancellationToken cancellationToken)
        {
            Logger.LogInformation("! Empezó la actualización de un diagnóstico");
            var entry = await Context.Diagnosticos
                .Where(x => x.Id == notification.Id)
                .Include(x => x.DetallesDiagnostico)
                .Include(x => x.PosiblesEnfermedades)
                .FirstOrDefaultAsync();

            using (var transaction = await Context.Database.BeginTransactionAsync())
            {
                Logger.LogInformation("! Preparando los detalles");
                PrepareDetails(entry, notification);

                Logger.LogInformation("! Preparando los resultados");
                PrepareEnfermedades(entry, notification);

                Logger.LogInformation("! Preparando la cabecera");
                PrepareHeader(entry, notification);

                Logger.LogInformation("! Guardando el diagnóstico");

                Context.Entry(entry).State = EntityState.Modified;
                await Context.SaveChangesAsync();

                Logger.LogInformation($"! El diagnóstico ha sido actualizado");

                await transaction.CommitAsync();
            }

            Logger.LogInformation("! Terminó la actualización de un diagnóstico");
        }

        public void PrepareDetails(Diagnostico entry, IDiagnosticoCommand notification)
        {
            entry.DetallesDiagnostico = notification.DetallesDiagnostico.Select(x => new DetalleDiagnostico
            {
                Diagnostico_Id = entry.Id,
                Pregunta_Id = x.Pregunta_Id,
                Respuesta = x.Respuesta
            }).ToList();
        }

        public void PrepareEnfermedades(Diagnostico entry, IDiagnosticoCommand notification)
        {
            var enfermedadesDiagnostico = DeterminarEnfermedades(notification);
            entry.PosiblesEnfermedades = enfermedadesDiagnostico.Select(x => new PosibleEnfermedad
            {
                Diagnostico_Id = entry.Id,
                Enfermedad_Id = x.Enfermedad_Id,
                Porcentaje = (decimal)x.Porcentaje
            }).ToList();
        }

        public void PrepareHeader(Diagnostico entry, IDiagnosticoCommand notification)
        {
            // Header information
            if (notification is DiagnosticoCreateCommand)
            {
                var createCommand = (DiagnosticoCreateCommand)notification;
                entry.Fecha = DateTime.UtcNow;
                entry.Paciente_Id = createCommand.Paciente_Id;
                entry.Especialidad_Id = createCommand.Especialidad_Id;
            }
            else if(notification is DiagnosticoUpdateCommand)
            {
                var updateCommand = (DiagnosticoUpdateCommand)notification;
                entry.Fecha = DateTime.UtcNow;
                entry.Id = updateCommand.Id;
            }
        }

        public List<EnfermedadDiagnostico> DeterminarEnfermedades(IDiagnosticoCommand notification)
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

            Logger.LogInformation($"Ruta del archivo: {absPath}");

            var enfermedades = Context.Enfermedades.Select(x => new EnfermedadDiagnostico
            {
                Enfermedad_Id = x.Id,
                Nombre = x.NombreClave,
                Cantidad = 0,
                Porcentaje = 0,
                CantSintomas = x.CantidadSintomas
            }).ToList();

            if (notification.DetallesDiagnostico == null || notification.DetallesDiagnostico.Count <= 0)
                throw new DiagnosticosDiagnosticoCreateCommandException($"No hay detalles de diagnostico en el diagnostico.");

            var detallesSintoma = notification.DetallesDiagnostico.ToList()
                .Where(x => x.Respuesta.Equals("Sí")).Select(x => x.Pregunta_Id).ToList();
            var preguntas = Context.Preguntas.ToList().Where(x => detallesSintoma.Contains(x.Id));

            foreach (var pregunta in preguntas)
            {
                var solutions = prolog
                    .GetAllSolutions(absPath, $"enfermedadde(Z, {pregunta.PalabraClave})")
                    .NextSolution;

                foreach (var solution in solutions)
                {
                    var coincidencia = solution.NextVariable.First().Value;

                    if (enfermedades.Select(x => x.Nombre).Contains(coincidencia))
                        enfermedades.Single(x => x.Nombre == coincidencia).Cantidad++;
                }
            }

            foreach (var enfermedad in enfermedades)
                enfermedad.Porcentaje = enfermedad.Cantidad * 100 / enfermedad.CantSintomas;

            var maxPorcentajes = enfermedades.OrderByDescending(x => x.Porcentaje).Take(4).ToList();

            if (maxPorcentajes[0].Porcentaje <= 0)
                throw new DiagnosticosDiagnosticoCreateCommandException($"No hay detalles de diagnostico con sintomas predefinidos en el diagnostico");

            return maxPorcentajes;
        }

        public class EnfermedadDiagnostico
        {
            public int Enfermedad_Id;
            public string Nombre;
            public int Cantidad;
            public double Porcentaje;
            public double CantSintomas;
        }
    }
}
