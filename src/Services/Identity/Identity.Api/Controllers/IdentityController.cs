using Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator Mediator;

        public IdentityController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("admin")]
        public async Task<IActionResult> SignUpAdmin(UsuarioAdminCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(command);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(UsuarioCreateCommand command) 
        {
            if (ModelState.IsValid) 
            {
                var result = await Mediator.Send(command);

                if (!result.Succeeded) 
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> SignIn(UsuarioLoginCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(command);

                if (!result.Succeeded)
                {
                    return BadRequest("Acceso denegado");
                }

                return Ok(result);
            }

            return BadRequest();
        }
    }
}
