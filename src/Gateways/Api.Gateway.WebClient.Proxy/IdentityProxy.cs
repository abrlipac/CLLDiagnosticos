using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Models.Identity.Responses;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy
{
    public interface IIdentityProxy
    {
        Task CreateAsync(UsuarioCreateCommand command);
        Task CreateAdminAsync(UsuarioAdminCreateCommand command);
        Task<IdentityAccess> AuthenticationAsync(UsuarioLoginCommand command);
    }

    public class IdentityProxy : IIdentityProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public IdentityProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<IdentityAccess> AuthenticationAsync(UsuarioLoginCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}identity/auth", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<IdentityAccess>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateAdminAsync(UsuarioAdminCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}identity/admin", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task CreateAsync(UsuarioCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}identity", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
