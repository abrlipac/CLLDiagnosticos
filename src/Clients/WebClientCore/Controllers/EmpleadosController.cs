using Api.Gateway.Models;
using Api.Gateway.Models.Personal;
using Api.Gateway.Models.Personal.Commands;
using Api.Gateway.Models.Personal.DTOs;
using Api.Gateway.WebClient.Proxy;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebClientCore.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class EmpleadosController : Controller
    {
        private readonly ILogger<EmpleadosController> _logger;
        private readonly IPersonalProxy _personalProxy;

        public DataCollection<EmpleadoDto> Empleados { get; set; }

        public EmpleadosController(ILogger<EmpleadosController> logger, IPersonalProxy personalProxy)
        {
            _personalProxy = personalProxy;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            Empleados = await _personalProxy.GetAllAsync(1, 10, null);

            if (!Empleados.HasItems)
            {
                return View();
            }

            return View(Empleados);
        }

        public async Task<ActionResult> Visualizar(int id)
        {
            var empleado = await _personalProxy.GetAsync(id);

            if (empleado != null)
            {
                return View(empleado);
            }
            return Redirect("~/Index");
        }

        // GET: Medicos/Create
        public ActionResult Agregar()
        {
            return View(new EmpleadoCreateCommand());
        }

        public async Task<ActionResult> Guardar(EmpleadoDto empleado)
        {
            if (ModelState.IsValid)
            {
                await _personalProxy.CreateAsync(new EmpleadoCreateCommand()
                {
                    Dni = empleado.Dni,
                    Activo = empleado.Activo,
                    Apellidos = empleado.Apellidos,
                    Nombres = empleado.Nombres
                });

                return Redirect("~/empleados");
            }
            else
            {
                return Redirect("~/empleados");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _personalProxy.DeleteAsync(new EmpleadoDeleteCommand() { Id = id });
            return Redirect("~/empleados");
        }
    }
}
