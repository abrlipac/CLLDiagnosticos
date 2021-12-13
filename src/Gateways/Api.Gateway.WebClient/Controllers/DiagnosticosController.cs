using Api.Gateway.Models;
using Api.Gateway.Models.Diagnosticos.Commands;
using Api.Gateway.Models.Diagnosticos.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("diagnosticos")]
    public class DiagnosticosController : ControllerBase
    {
        private readonly IDiagnosticosProxy _diagnosticosProxy;

        public DiagnosticosController(
            IDiagnosticosProxy diagnosticosProxy
        )
        {
            _diagnosticosProxy = diagnosticosProxy;
        }

        [HttpGet]
        public async Task<DataCollection<DiagnosticoDto>> GetAll(int page = 1, int take = 10)
        {
            return await _diagnosticosProxy.GetAllAsync(page, take);
        }

        [HttpGet("especialidades")]
        public async Task<DataCollection<EspecialidadDto>> GetAllEspecialidades(int page = 1, int take = 10)
        {
            return await _diagnosticosProxy.GetAllEspecialidadesAsync(page, take);
        }

        [HttpGet("preguntas")]
        public async Task<DataCollection<PreguntaDto>> GetAllPreguntas(int espId, int page = 1, int take = 10)
        {
            return await _diagnosticosProxy.GetAllPreguntasAsync(espId, page, take);
        }

        [HttpGet("{id}")]
        public async Task<DiagnosticoDto> Get(int id)
        {
            return await _diagnosticosProxy.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DiagnosticoCreateCommand notification)
        {
            await _diagnosticosProxy.CreateAsync(notification);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(DiagnosticoUpdateCommand notification)
        {
            await _diagnosticosProxy.UpdateAsync(notification);
            return Ok();
        }
    }
}
