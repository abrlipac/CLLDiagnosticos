using Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator Mediator;

        public IdentityController(
            IMediator mediator)
        {
            Mediator = mediator;
        }

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
