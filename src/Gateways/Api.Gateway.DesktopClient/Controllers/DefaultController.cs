using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.WebClient
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Index() => "Diagnostico is running";
    }
}
