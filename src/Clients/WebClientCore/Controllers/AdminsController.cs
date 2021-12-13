using Api.Gateway.Models;
using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Models.Identity.DTOs;
using Api.Gateway.Models.Personal.Commands;
using Api.Gateway.Models.Personal.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System.Linq;
using System.Threading.Tasks;
using WebClientCore.Models;
using WebClientCore.Resources;
using WebClientCore.Service;

namespace WebClientCore.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AdminsController : Controller
    {
        private readonly ILogger<AdminsController> _logger;
        private readonly string BaseUrl = ApiUrls.BaseUrl;

        public DataCollection<AdminDto> Admins { get; set; }

        public AdminsController(ILogger<AdminsController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index(int take = 10, int page = 1)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var webClientApi = RestService.For<IWebClientService>(BaseUrl, refitSettings);

            DataCollection<AdminDto> response =
                await webClientApi.GetAdmins(GetToken(), take, page);

            /*
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }*/

            var admins = response;

            if (!admins.HasItems)
            {
                return View();
            }

            return View(admins);
        }

        public async Task<ActionResult> Visualizar(int id)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var webClientApi = RestService.For<IWebClientService>(BaseUrl, refitSettings);
            AdminDto response = await webClientApi.GetAdmin(id, GetToken());
            /*
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("~/admins");
            }

            var admin = response.Content;

            if (admin != null)
            {
                return Redirect("~/admins");
            }*/

            return View(response);
        }

        public ActionResult Agregar()
        {
            return View(new CreateAdminViewModel());
        }

        public async Task<ActionResult> Guardar(CreateAdminViewModel createAdmin)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var webClientApi = RestService.For<IWebClientService>(BaseUrl, refitSettings);

            if (!ModelState.IsValid)
            {
                ViewData["error"] = "Compruebe los datos ingresados";
                return View(createAdmin);
            }

            if (createAdmin.Password != createAdmin.RepetirPassword)
            {
                ViewData["error"] = "Las contraseñas no coinciden";
                return View(createAdmin);
            }

            var usuarioAdminCreate = new UsuarioAdminCreateCommand
            {
                NombreCompleto = $"{createAdmin.AdminCreate.Nombres} {createAdmin.AdminCreate.Apellidos}",
                Password = createAdmin.Password,
                UserName = createAdmin.UserName
            };

            await webClientApi.SignupAdmin(usuarioAdminCreate, GetToken());

            /*
            if(!usuarioResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo registrar al usuario";
                return View(signup);
            }*/

            ApiResponse<UsuarioDto> getUsuarioResponse = await webClientApi.GetUser(createAdmin.UserName);

            if (!getUsuarioResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo encontrar al usuario creado";
                return View(createAdmin);
            }

            var userId = getUsuarioResponse.Content.Id;

            var adminCreate = new AdminCreateCommand
            {
                Activo = true,
                Apellidos = createAdmin.AdminCreate.Apellidos,
                Nombres = createAdmin.AdminCreate.Nombres,
                Dni = createAdmin.AdminCreate.Dni,
                Usuario_Id = userId
            };

            await webClientApi.CreateAdmin(adminCreate, GetToken());

            /*
            if (!pacienteResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo registrar al paciente";
                return View(signup);
            }*/

            return Redirect("~/admins");
        }

        public async Task<ActionResult> Eliminar(int id)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var webClientApi = RestService.For<IWebClientService>(ApiUrls.PersonalUrl, refitSettings);

            await webClientApi.DeleteAdmin(new AdminDeleteCommand { Id = id }, GetToken());
            return Redirect("~/admins");
        }

        private string GetToken()
            => User.Claims
                .ToList()
                .Where(x => x.Type.Equals("access_token"))
                .SingleOrDefault()
                .Value;
    }
}
