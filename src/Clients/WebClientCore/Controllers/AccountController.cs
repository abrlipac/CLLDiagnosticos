using Api.Gateway.Models.Clientes.Commands;
using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Models.Identity.DTOs;
using Api.Gateway.Models.Identity.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebClientCore.Models;
using WebClientCore.Resources;
using WebClientCore.Service;

namespace WebClientCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly string BaseUrl = ApiUrls.BaseUrl;

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel() { HasInvalidAccess = false });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var webClientApi = RestService.For<IWebClientService>(BaseUrl, refitSettings);

            if (!ModelState.IsValid)
                return View();

            ApiResponse<IdentityAccess> response = await webClientApi.Login(model.UsuarioLogin);

            if (!response.IsSuccessStatusCode)
            {
                model.HasInvalidAccess = true;
                return View(model);
            }

            return Redirect(model.ReturnBaseUrl + $"connect?access_token={response.Content.AccessToken}");
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Signup(SignupViewModel signup)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var webClientApi = RestService.For<IWebClientService>(BaseUrl, refitSettings);

            if (!ModelState.IsValid)
            {
                ViewData["error"] = "Compruebe los datos ingresados";
                return View(signup);
            }

            if (signup.Password != signup.RepetirPassword)
            {
                ViewData["error"] = "Las contraseñas no coinciden";
                return View(signup);
            }

            var usuarioCreate = new UsuarioCreateCommand
            {
                NombreCompleto = $"{signup.PacienteCreate.Nombres} {signup.PacienteCreate.Apellidos}",
                Password = signup.Password,
                UserName = signup.UserName
            };

            await webClientApi.Signup(usuarioCreate);

            /*
            if(!usuarioResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo registrar al usuario";
                return View(signup);
            }*/

            ApiResponse<UsuarioDto> getUsuarioResponse = await webClientApi.GetUser(signup.UserName);

            if (!getUsuarioResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo encontrar al usuario creado";
                return View(signup);
            }

            var userId = getUsuarioResponse.Content.Id;

            var pacienteCreate = new PacienteCreateCommand
            {
                Activo = true,
                Apellidos = signup.PacienteCreate.Apellidos,
                Nombres = signup.PacienteCreate.Nombres,
                Dni = signup.PacienteCreate.Dni,
                Celular = signup.PacienteCreate.Celular,
                Email = signup.PacienteCreate.Email,
                FechaNacimiento = signup.PacienteCreate.FechaNacimiento,
                Region = signup.PacienteCreate.Region,
                Sexo = signup.PacienteCreate.Sexo,
                Usuario_Id = userId
            };

            await webClientApi.CreatePaciente(pacienteCreate);

            /*
            if (!pacienteResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo registrar al paciente";
                return View(signup);
            }*/

            return Redirect("~/account/login");
        }

        [HttpGet]
        public async Task<ActionResult> Connect(string access_token)
        {
            var token = access_token.Split('.');
            var paddedContent = token[1].PadRight(token[1].Length + (token[1].Length * 3) % 4, '=');

            var base64Content = Convert.FromBase64String(paddedContent);

            var user = JsonSerializer.Deserialize<AccessTokenUserInformation>(base64Content);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.nameid),
                new Claim(ClaimTypes.Name, user.unique_name),
                new Claim(ClaimTypes.Role, user.role),
                new Claim("access_token", access_token)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow.AddHours(10)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return Redirect("~/");
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("~/account/login");
        }
    }
}
