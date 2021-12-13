using Api.Gateway.Models;
using Api.Gateway.Models.Identity.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient
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

        [AllowAnonymous]
        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var paciente = await _usuarioProxy.GetAsync(username);
            if (paciente is null)
                return NotFound($"No se ha encontrado a un usuario con el UserName {username}");
            return Ok(paciente);
        }
    }
}
