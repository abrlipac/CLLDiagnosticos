using Api.Gateway.Models;
using Api.Gateway.Models.Clientes.Commands;
using Api.Gateway.Models.Clientes.DTOs;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy
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
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public ClientesProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<PacienteDto>> GetAllAsync(int page, int take, IEnumerable<int> pacientes = null)
        {
            var ids = string.Join(',', pacientes ?? new List<int>());

            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}pacientes?page={page}&take={take}&ids={ids}");
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
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}pacientes/{id}");
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

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}pacientes", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task UpdateContactInfoAsync(PacienteUpdateContactInfoCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PatchAsync($"{_apiGatewayUrl}pacientes", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
