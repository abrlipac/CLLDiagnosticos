using Api.Gateway.Models;
using Api.Gateway.Models.Clientes.DTOs;
using Api.Gateway.Models.Diagnosticos.Commands;
using Api.Gateway.Models.Diagnosticos.DTOs;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebClientBlazor.Service
{
    public interface IWebClientService
    {
        [Post("/diagnosticos")]
        Task CreateDiagnostico(DiagnosticoCreateCommand diagnosticoCreate, [Authorize("Bearer")] string token);

        [Get("/diagnosticos/especialidades")]
        Task<DataCollection<EspecialidadDto>> GetEspecialidades([Authorize("Bearer")] string token);

        [Get("/diagnosticos/preguntas")]
        Task<DataCollection<PreguntaDto>> GetPreguntasEsp([Authorize("Bearer")] string token, int espId = 4, int take = 30);


        [Get("/pacientes")]
        Task<DataCollection<PacienteDto>> GetPacientes([Authorize("Bearer")] string token, string usuarioId);
    }
}
