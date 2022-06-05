using Clientes.Domain;
using Clientes.Persistence.Database;
using Clientes.Service.EventHandlers.Commands;
using Clientes.Service.EventHandlers.DTOs;
using Clientes.Service.EventHandlers.Responses;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.Service.EventHandlers
{
    public class PacienteEventHandler :
        IRequestHandler<PacienteCreateCommand, Result>,
        IRequestHandler<PacienteUpdateContactInfoCommand, Result>
    {
        private readonly ApplicationDbContext _context;

        public PacienteEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(PacienteCreateCommand command, CancellationToken cancellationToken)
        {
            var paciente = command.Adapt<Paciente>();

            try
            {
                await _context.AddAsync(paciente);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new Result
                {
                    Succeed = false,
                    Error = e.Message
                };
            }
            return new Result
            {
                Succeed = true,
                Paciente = paciente.Adapt<PacienteDto>()
            };
        }

        public async Task<Result> Handle(PacienteUpdateContactInfoCommand command, CancellationToken cancellationToken)
        {
            var originalPaciente =
                await _context.Pacientes
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Id == command.Id,
                        cancellationToken: cancellationToken);

            if (originalPaciente == null)
                return new Result
                {
                    Succeed = false,
                    Error = $"No se encontró al paciente con Id {command.Id}"
                };


            var updatedPaciente = originalPaciente;

            updatedPaciente.Email = command.Email;
            updatedPaciente.Celular = command.Celular;

            try
            {
                _context.Update(updatedPaciente);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new Result
                {
                    Succeed = false,
                    Error = e.Message
                };
            }
            return new Result
            {
                Succeed = true
            };
        }
    }
}
