using Microsoft.AspNetCore.Mvc;

namespace Diagnosticos.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Diagnosticos.Api is running";
        }
    }
}
