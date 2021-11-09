using Api.Gateway.Models;
using Api.Gateway.Models.Clientes.Commands;
using Api.Gateway.Models.Clientes.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Gateway.DesktopClient
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("pacientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesProxy _clientesProxy;

        public ClientesController(
            IClientesProxy clientesProxy
        )
        {
            _clientesProxy = clientesProxy;
        }

        [HttpGet]
        public async Task<DataCollection<PacienteDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> pacientesIds = null;

            if (!string.IsNullOrEmpty(ids))
            {
                pacientesIds = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _clientesProxy.GetAllAsync(page, take, pacientesIds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = await _clientesProxy.GetAsync(id);
            if (paciente is null)
                return NotFound($"No se ha encontrado a un paciente con Id {id}");
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteCreateCommand notification)
        {
            await _clientesProxy.CreateAsync(notification);
            return Created("", "Se ha creado el paciente correctamente");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateContactInfo(PacienteUpdateContactInfoCommand notification)
        {
            await _clientesProxy.UpdateContactInfoAsync(notification);
            return Ok("Se han actualizado los datos de contacto del paciente");
        }
    }
}
