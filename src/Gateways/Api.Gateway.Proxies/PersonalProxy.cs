using Api.Gateway.Models;
using Api.Gateway.Models.Personal.Commands;
using Api.Gateway.Models.Personal.DTOs;
using Api.Gateway.Proxies.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public interface IPersonalProxy
    {
        Task<DataCollection<EmpleadoDto>> GetAllAsync(int page, int take, string dni);
        Task<EmpleadoDto> GetAsync(int id);
        Task CreateAsync(EmpleadoCreateCommand command);
        Task UpdateActivoAsync(EmpleadoUpdateActivoCommand command);
        Task DeleteAsync(EmpleadoDeleteCommand command);
    }
    public class PersonalProxy : IPersonalProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public PersonalProxy(
            HttpClient httpClient,
            IOptions<ApiUrls> apiUrls,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<DataCollection<EmpleadoDto>> GetAllAsync(int page, int take, string dni)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.PersonalUrl}empleados?dni={dni}&page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<EmpleadoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<EmpleadoDto> GetAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.PersonalUrl}empleados/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<EmpleadoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateAsync(EmpleadoCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.PersonalUrl}empleados", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task UpdateActivoAsync(EmpleadoUpdateActivoCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PatchAsync($"{_apiUrls.PersonalUrl}empleados", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(EmpleadoDeleteCommand command)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrls.PersonalUrl}empleados/{command.Id}");
            request.EnsureSuccessStatusCode();
        }
    }
}
