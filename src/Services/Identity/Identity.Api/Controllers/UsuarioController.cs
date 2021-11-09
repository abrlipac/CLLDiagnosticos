using Identity.Service.Queries;
using Identity.Service.Queries.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioQueryService _usuarioQueryService;

        public UsuarioController(
            IUsuarioQueryService usuarioQueryService)
        {
            _usuarioQueryService = usuarioQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<UsuarioDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<string> users = ids?.Split(',');
            return await _usuarioQueryService.GetAllAsync(page, take, users);
        }

        [HttpGet("{id}")]
        public async Task<UsuarioDto> Get(string id)
        {
            return await _usuarioQueryService.GetAsync(id);
        }
    }
}
