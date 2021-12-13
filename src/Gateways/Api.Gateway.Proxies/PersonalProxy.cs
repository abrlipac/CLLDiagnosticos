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
        Task<DataCollection<AdminDto>> GetAllAsync(int page, int take, string dni);
        Task<AdminDto> GetAsync(int id);
        Task CreateAsync(AdminCreateCommand command);
        Task UpdateActivoAsync(AdminUpdateActivoCommand command);
        Task DeleteAsync(AdminDeleteCommand command);
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

        public async Task<DataCollection<AdminDto>> GetAllAsync(int page, int take, string dni)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.PersonalUrl}admins?dni={dni}&page={page}&take={take}");
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
            var request = await _httpClient.GetAsync($"{_apiUrls.PersonalUrl}admins/{id}");
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

            var request = await _httpClient.PostAsync($"{_apiUrls.PersonalUrl}admins", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task UpdateActivoAsync(AdminUpdateActivoCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PatchAsync($"{_apiUrls.PersonalUrl}admins", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(AdminDeleteCommand command)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrls.PersonalUrl}admins/{command.Id}");
            request.EnsureSuccessStatusCode();
        }
    }
}
