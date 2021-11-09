using Clientes.Service.EventHandlers.Commands;
using Clientes.Service.Queries.DTOs;
using Clientes.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Clientes.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("pacientes")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteQueryService _pacienteQueryService;
        private readonly IMediator _mediator;

        public PacienteController(
            IMediator mediator,
            IPacienteQueryService pacienteQueryService)
        {
            _mediator = mediator;
            _pacienteQueryService = pacienteQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<PacienteDto>> GetAll(int page = 1, int take = 10, string ids = null, string dni = null) 
        {
            IEnumerable<int> pacientesIds = null;

            if (!string.IsNullOrEmpty(ids)) 
            {
                pacientesIds = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _pacienteQueryService.GetAllAsync(dni, page, take, pacientesIds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = await _pacienteQueryService.GetAsync(id);
            if (paciente is null)
                return NotFound($"No se ha encontrado a un paciente con Id {id}");
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Created("", "Se ha creado el paciente correctamente");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateContactInfo(PacienteUpdateContactInfoCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok("Se han actualizado los datos de contacto del paciente");
        }
    }
}
