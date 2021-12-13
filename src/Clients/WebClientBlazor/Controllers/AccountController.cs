using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebClientBlazor.Models;

namespace WebClientBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
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

            return Redirect("/diagnosticos/chatbot");
        }
    }
}
