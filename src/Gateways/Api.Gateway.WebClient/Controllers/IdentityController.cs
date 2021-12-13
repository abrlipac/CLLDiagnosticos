using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityProxy _identityProxy;

        public IdentityController(
            IIdentityProxy identityProxy
        )
        {
            _identityProxy = identityProxy;
        }

        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdmin(UsuarioAdminCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                await _identityProxy.CreateAdminAsync(command);
                return Ok();
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                await _identityProxy.CreateAsync(command);
                return Ok();
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> Authentication(UsuarioLoginCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityProxy.AuthenticationAsync(command);

                if (!result.Succeeded)
                {
                    return BadRequest("Access denied");
                }

                return Ok(result);
            }

            return BadRequest();
        }
    }
}
