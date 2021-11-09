using Diagnosticos.Service.EventHandlers.Commands;
using Diagnosticos.Service.Queries.DTOs;
using Diagnosticos.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Service.Common.Collection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Diagnosticos.Service.EventHandlers.Exceptions;
using Diagnosticos.Service.Queries.Exceptions;

namespace Diagnosticos.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("diagnosticos")]
    public class DiagnosticosController : ControllerBase
    {
        private readonly IDiagnosticoQueryService _diagnosticoQueryService;
        private readonly IMediator _mediator;

        public DiagnosticosController(
            IMediator mediator,
            IDiagnosticoQueryService diagnosticoQueryService)
        {
            _mediator = mediator;
            _diagnosticoQueryService = diagnosticoQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<DiagnosticoDto>> GetAll(int page = 1, int take = 10) 
        {
            return await _diagnosticoQueryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiagnosticoDto>> Get(int id)
        {
            try
            {
                return await _diagnosticoQueryService.GetAsync(id);
            }
            catch (DiagnosticosGetDiagnosticoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiagnosticoCreateCommand notification)
        {
            try
            {
                await _mediator.Publish(notification);
                return Ok();
            }
            catch (DiagnosticosDiagnosticoCreateCommandException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
