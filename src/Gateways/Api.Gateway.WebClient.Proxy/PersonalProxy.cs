using Api.Gateway.Models;
using Api.Gateway.Models.Personal.Commands;
using Api.Gateway.Models.Personal.DTOs;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy
{
    public interface IPersonalProxy
    {
        Task<DataCollection<AdminDto>> GetAllAsync(int page, int take, string dni);
        Task<AdminDto> GetAsync(int id);
        Task CreateAsync(AdminCreateCommand command);
        Task UpdateActivoAsync(AdminUpdateActivoCommand command);
        Task DeleteAsync(AdminDeleteCommand command);
    }

    public class PersonalProxy : IPersonalProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public PersonalProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<AdminDto>> GetAllAsync(int page, int take, string dni)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}empleados?dni={dni}&page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<AdminDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<AdminDto> GetAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}empleados/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AdminDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateAsync(AdminCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}empleados", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task UpdateActivoAsync(AdminUpdateActivoCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PatchAsync($"{_apiGatewayUrl}empleados", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(AdminDeleteCommand command)
        {
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}empleados/{command.Id}");
            request.EnsureSuccessStatusCode();
        }
    }
}
