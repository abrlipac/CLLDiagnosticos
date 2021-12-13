using Api.Gateway.Models;
using Api.Gateway.Models.Diagnosticos.DTOs;
using Api.Gateway.Models.Diagnosticos.Commands;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy
{
    public interface IDiagnosticosProxy
    {
        Task<DataCollection<DiagnosticoDto>> GetAllAsync(int page, int take);
        Task<DataCollection<EspecialidadDto>> GetAllEspecialidadesAsync(int page, int take);
        Task<DataCollection<PreguntaDto>> GetAllPreguntasAsync(int espId, int page, int take);
        Task<DiagnosticoDto> GetAsync(int id);
        Task CreateAsync(DiagnosticoCreateCommand command);
        Task UpdateAsync(DiagnosticoUpdateCommand command);
    }

    public class DiagnosticosProxy : IDiagnosticosProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public DiagnosticosProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task CreateAsync(DiagnosticoCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}diagnosticos", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task<DataCollection<DiagnosticoDto>> GetAllAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}diagnosticos?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<DiagnosticoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<DataCollection<EspecialidadDto>> GetAllEspecialidadesAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}diagnosticos/especialidades?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<EspecialidadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<DataCollection<PreguntaDto>> GetAllPreguntasAsync(int espId, int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}diagnosticos/preguntas?espId={espId}&page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<PreguntaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<DiagnosticoDto> GetAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}diagnosticos/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DiagnosticoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task UpdateAsync(DiagnosticoUpdateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}diagnosticos", content);
            request.EnsureSuccessStatusCode();
        }
    }
}
