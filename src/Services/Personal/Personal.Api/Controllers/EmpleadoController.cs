using Personal.Service.EventHandlers.Commands;
using Personal.Service.Queries.DTOs;
using Personal.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Personal.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("empleados")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoQueryService _empleadoQueryService;
        private readonly IMediator _mediator;

        public EmpleadoController(
            IMediator mediator,
            IEmpleadoQueryService empleadoQueryService)
        {
            _mediator = mediator;
            _empleadoQueryService = empleadoQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<EmpleadoDto>> GetAll(int page = 1, int take = 10, string ids = null, string dni = null) 
        {
            IEnumerable<int> empleadosIds = null;

            if (!string.IsNullOrEmpty(ids)) 
            {
                empleadosIds = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _empleadoQueryService.GetAllAsync(dni, page, take, empleadosIds);
        }

        [HttpGet("{id}")]
        public async Task<EmpleadoDto> Get(int id)
        {
            return await _empleadoQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpleadoCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateActivo(EmpleadoUpdateActivoCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EmpleadoDeleteCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }
    }
}
