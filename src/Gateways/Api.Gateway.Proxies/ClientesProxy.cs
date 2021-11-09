using Api.Gateway.Models;
using Api.Gateway.Models.Clientes.Commands;
using Api.Gateway.Models.Clientes.DTOs;
using Api.Gateway.Proxies.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public interface IClientesProxy
    {
        Task<DataCollection<PacienteDto>> GetAllAsync(int page, int take, IEnumerable<int> pacientes = null);
        Task<PacienteDto> GetAsync(int id);
        Task CreateAsync(PacienteCreateCommand command);
        Task UpdateContactInfoAsync(PacienteUpdateContactInfoCommand command);
    }
    public class ClientesProxy : IClientesProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public ClientesProxy(
            HttpClient httpClient,
            IOptions<ApiUrls> apiUrls,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<DataCollection<PacienteDto>> GetAllAsync(int page, int take, IEnumerable<int> pacientes = null)
        {
            var ids = string.Join(',', pacientes ?? new List<int>());

            var request = await _httpClient.GetAsync($"{_apiUrls.ClientesUrl}pacientes?page={page}&take={take}&ids={ids}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<PacienteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<PacienteDto> GetAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.ClientesUrl}pacientes/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<PacienteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateAsync(PacienteCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.ClientesUrl}pacientes", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task UpdateContactInfoAsync(PacienteUpdateContactInfoCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PatchAsync($"{_apiUrls.ClientesUrl}pacientes", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
