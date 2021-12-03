using Personal.Service.EventHandlers.Commands;
using Personal.Service.Queries.DTOs;
using Personal.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Personal.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("admins")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminQueryService AdministradorQueryService;
        private readonly IMediator Mediator;

        public AdminController(
            IMediator mediator,
            IAdminQueryService administradorQueryService)
        {
            Mediator = mediator;
            AdministradorQueryService = administradorQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<AdminDto>> GetAll(int page = 1, int take = 10, string ids = null, string dni = null) 
        {
            IEnumerable<int> adminsIds = null;

            if (!string.IsNullOrEmpty(ids)) 
            {
                adminsIds = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await AdministradorQueryService.GetAllAsync(dni, page, take, adminsIds);
        }

        [HttpGet("{id}")]
        public async Task<AdminDto> Get(int id)
        {
            return await AdministradorQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateCommand notification)
        {
            await Mediator.Publish(notification);
            return Created("", "Se ha creado el administrador correctamente");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateActivo(AdminUpdateActivoCommand notification)
        {
            await Mediator.Publish(notification);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(AdminDeleteCommand notification)
        {
            await Mediator.Publish(notification);
            return Ok();
        }
    }
}
