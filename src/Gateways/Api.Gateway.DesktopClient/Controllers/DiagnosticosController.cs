using Api.Gateway.Models;
using Api.Gateway.Models.Diagnosticos.Commands;
using Api.Gateway.Models.Diagnosticos.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.DesktopClient
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
    }
}
