using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.DesktopClient
{
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

        [HttpPost("authentication")]
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
