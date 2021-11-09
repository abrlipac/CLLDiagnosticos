using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.DesktopClient
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Index() => "Diagnostico is running";
    }
}
