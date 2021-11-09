using Api.Gateway.Models.Identity.Commands;
using Api.Gateway.Models.Identity.Responses;
using Api.Gateway.Proxies.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public interface IIdentityProxy
    {
        Task CreateAsync(UsuarioCreateCommand command);
        Task<IdentityAccess> AuthenticationAsync(UsuarioLoginCommand command);
    }
    public class IdentityProxy : IIdentityProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public IdentityProxy(
            HttpClient httpClient,
            IOptions<ApiUrls> apiUrls,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<IdentityAccess> AuthenticationAsync(UsuarioLoginCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.IdentityUrl}identity/authentication", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<IdentityAccess>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateAsync(UsuarioCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.IdentityUrl}identity", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
