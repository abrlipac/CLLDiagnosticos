using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClientCore.Models;

namespace WebClientCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _identityUrl = "http://localhost:10003/";

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel() { HasInvalidAccess = false });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            using var client = new HttpClient();
            var content = new StringContent(
                JsonSerializer.Serialize(model.UsuarioLogin, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }),
                Encoding.UTF8,
                "application/json"
            );

            var request = await client.PostAsync(_identityUrl + "identity/authentication", content);

            if (!request.IsSuccessStatusCode)
            {
                model.HasInvalidAccess = true;
                return View(model);
            }

            var result = JsonSerializer.Deserialize<IdentityAccess>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

            return Redirect(model.ReturnBaseUrl + $"connect?access_token={result.AccessToken}");
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Signup(UsuarioCreate model)
        {
            if (!ModelState.IsValid)
                return View();

            using var client = new HttpClient();
            var content = new StringContent(
                JsonSerializer.Serialize(model, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }),
                Encoding.UTF8,
                "application/json"
            );

            var request = await client.PostAsync(_identityUrl + "identity", content);

            if (!request.IsSuccessStatusCode)
            {
                return View(model);
            }

            return Redirect("login");
        }

        [HttpGet]
        public async Task<ActionResult> Connect(string access_token)
        {
            var token = access_token.Split('.');
            var base64Content = Convert.FromBase64String(token[1]);

            var user = JsonSerializer.Deserialize<AccessTokenUserInformation>(base64Content);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.nameid),
                new Claim(ClaimTypes.Name, user.unique_name),
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
            return Redirect("~/");
        }
    }
}
