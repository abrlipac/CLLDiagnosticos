using Api.Gateway.Models;
using Api.Gateway.Models.Identity.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.DesktopClient
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioProxy _usuarioProxy;

        public UsuariosController(
            IUsuarioProxy usuarioProxy
        )
        {
            _usuarioProxy = usuarioProxy;
        }

        [HttpGet]
        public async Task<DataCollection<UsuarioDto>> GetAll(int page = 1, int take = 10)
        {
            return await _usuarioProxy.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = await _usuarioProxy.GetAsync(id);
            if (paciente is null)
                return NotFound($"No se ha encontrado a un usuario con Id {id}");
            return Ok(paciente);
        }
    }
}
