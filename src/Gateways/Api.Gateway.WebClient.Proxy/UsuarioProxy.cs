using Api.Gateway.Models;
using Api.Gateway.Models.Identity.DTOs;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy
{
    public interface IUsuarioProxy
    {
        Task<DataCollection<UsuarioDto>> GetAllAsync(int page, int take);
        Task<UsuarioDto> GetAsync(string username);
    }

    public class UsuarioProxy : IUsuarioProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public UsuarioProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<UsuarioDto>> GetAllAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<UsuarioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<UsuarioDto> GetAsync(string username)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios/{username}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<UsuarioDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
