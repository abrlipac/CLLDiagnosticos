using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Api.Gateway.Proxies;
using Api.Gateway.Models.Personal.DTOs;
using Api.Gateway.Models;
using Api.Gateway.Models.Personal.Commands;

namespace Api.Gateway.DesktopClient
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("empleados")]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalProxy _personalProxy;

        public PersonalController(
            IPersonalProxy personalProxy
        )
        {
            _personalProxy = personalProxy;
        }

        [HttpGet]
        public async Task<DataCollection<EmpleadoDto>> GetAll(int page = 1, int take = 10, string dni = null)
        {
            return await _personalProxy.GetAllAsync(page, take, dni);
        }

        [HttpGet("{id}")]
        public async Task<EmpleadoDto> Get(int id)
        {
            return await _personalProxy.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpleadoCreateCommand notification)
        {
            await _personalProxy.CreateAsync(notification);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateActivo(EmpleadoUpdateActivoCommand notification)
        {
            await _personalProxy.UpdateActivoAsync(notification);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EmpleadoDeleteCommand notification)
        {
            await _personalProxy.DeleteAsync(notification);
            return Ok();
        }
    }
}
