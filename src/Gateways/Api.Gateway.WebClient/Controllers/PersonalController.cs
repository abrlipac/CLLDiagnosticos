using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Api.Gateway.Proxies;
using Api.Gateway.Models.Personal.DTOs;
using Api.Gateway.Models;
using Api.Gateway.Models.Personal.Commands;

namespace Api.Gateway.WebClient
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("admins")]
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
        public async Task<DataCollection<AdminDto>> GetAll(int page = 1, int take = 10, string dni = null)
        {
            return await _personalProxy.GetAllAsync(page, take, dni);
        }

        [HttpGet("{id}")]
        public async Task<AdminDto> Get(int id)
        {
            return await _personalProxy.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateCommand notification)
        {
            await _personalProxy.CreateAsync(notification);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateActivo(AdminUpdateActivoCommand notification)
        {
            await _personalProxy.UpdateActivoAsync(notification);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(AdminDeleteCommand notification)
        {
            await _personalProxy.DeleteAsync(notification);
            return Ok();
        }
    }
}
