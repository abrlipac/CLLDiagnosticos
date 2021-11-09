using Api.Gateway.Models;
using Api.Gateway.Models.Diagnosticos.Commands;
using Api.Gateway.Models.Diagnosticos.DTOs;
using Api.Gateway.Proxies.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public interface IDiagnosticosProxy
    {
        Task<DataCollection<DiagnosticoDto>> GetAllAsync(int page, int take);
        Task<DiagnosticoDto> GetAsync(int id);
        Task CreateAsync(DiagnosticoCreateCommand command);
    }
    public class DiagnosticosProxy : IDiagnosticosProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public DiagnosticosProxy(
            HttpClient httpClient,
            IOptions<ApiUrls> apiUrls,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task CreateAsync(DiagnosticoCreateCommand command)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.DiagnosticosUrl}diagnosticos", content);
            request.EnsureSuccessStatusCode();
        }

        public async Task<DataCollection<DiagnosticoDto>> GetAllAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.DiagnosticosUrl}diagnosticos?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<DiagnosticoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<DiagnosticoDto> GetAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.DiagnosticosUrl}diagnosticos/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DiagnosticoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
