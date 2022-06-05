using Api.Gateway.Models.Clientes.Commands;
using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Models.Identity.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebClientBlazor.Models;
using WebClientBlazor.Resources;
using WebClientBlazor.Service;

namespace WebClientBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly string IdentityUrl = ApiUrls.IdentityUrl;
        private readonly string PersonalUrl = ApiUrls.PersonalUrl;

        [HttpGet("[action]")]
        public async Task<IActionResult> Connect(string access_token)
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

            new AuthenticationState(new ClaimsPrincipal(claimsIdentity));

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            AuthUser.UserId = user.nameid;
            AuthUser.UserName = user.unique_name;
            AuthUser.AccessToken = access_token;
            AuthUser.isAuthenticated = true;

            return Redirect("/");
        }

        [HttpPost]
        public async Task<ActionResult> Signup(SignupViewModel signup)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var identityApi = RestService.For<IWebClientService>(IdentityUrl, refitSettings);
            var clientesApi = RestService.For<IWebClientService>(PersonalUrl, refitSettings);

            /*if (!ModelState.IsValid)
            {
                ViewData["error"] = "Compruebe los datos ingresados";
                return View(signup);
            }

            if (signup.Password != signup.RepetirPassword)
            {
                ViewData["error"] = "Las contraseñas no coinciden";
                return View(signup);
            }*/

            var usuarioCreate = new UsuarioCreateCommand
            {
                NombreCompleto = $"{signup.PacienteCreate.Nombres} {signup.PacienteCreate.Apellidos}",
                Password = signup.Password,
                UserName = signup.UserName
            };

            await identityApi.Signup(usuarioCreate);

            /*
            if(!usuarioResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo registrar al usuario";
                return View(signup);
            }*/

            ApiResponse<UsuarioDto> getUsuarioResponse = await identityApi.GetUser(signup.UserName);

            /*if (!getUsuarioResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo encontrar al usuario creado";
                return View(signup);
            }*/

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

            await clientesApi.CreatePaciente(pacienteCreate);

            /*
            if (!pacienteResponse.IsSuccessStatusCode)
            {
                ViewData["error"] = "No se pudo registrar al paciente";
                return View(signup);
            }*/

            return Redirect("/login");
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/login");
        }
    }
}
