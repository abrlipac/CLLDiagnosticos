using Microsoft.EntityFrameworkCore;
using Diagnosticos.Persistence.Database;
using Diagnosticos.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Linq;
using System.Threading.Tasks;
using Diagnosticos.Service.Queries.Exceptions;
using System;
using Mapster;

namespace Diagnosticos.Service.Queries
{
    public interface IDiagnosticoQueryService
    {
        Task<DataCollection<DiagnosticoDto>> GetAllAsync(int? paciente_Id, int page, int take);
        Task<DataCollection<EnfermedadDiagnosticoDto>> GetAllEnfermedadesAsync(int? paciente_Id, int page, int take);
        Task<DiagnosticoDto> GetAsync(int id);
        Task<ResultadoDiagnosticoDto> GetResultadoAsync(int id);
        Task<DataCollection<EspecialidadDto>> GetAllEspecialidadesAsync(int page, int take);
        Task<DataCollection<PreguntaDto>> GetAllPreguntasAsync(int? espId, int page, int take);
    }

    public class DiagnosticoQueryService : IDiagnosticoQueryService
    {
        private readonly ApplicationDbContext _context;

        public DiagnosticoQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<DiagnosticoDto>> GetAllAsync(int? pacienteId, int page, int take)
        {
            var collection = await _context.Diagnosticos
                .Include(x => x.DetallesDiagnostico)
                .Include(x => x.PosiblesEnfermedades)
                .Where(x => pacienteId == null || x.Paciente_Id == pacienteId)
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<DiagnosticoDto>>();
        }

        public async Task<DataCollection<EnfermedadDiagnosticoDto>> GetAllEnfermedadesAsync(int? paciente_Id, int page, int take)
        {
            var collection = await _context.Diagnosticos
                .Include(x => x.PosiblesEnfermedades)
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);
            var enfermedades = _context.Enfermedades;
            var diagnosticos = collection.MapTo<DataCollection<EnfermedadDiagnosticoDto>>();

            diagnosticos.Items = diagnosticos.Items.Select(ed =>
            {
                var enfermedad = ed.PosiblesEnfermedades.MaxBy(pe => pe.Porcentaje);

                return new EnfermedadDiagnosticoDto
                {
                    Id = ed.Id,
                    Especialidad_Id = ed.Especialidad_Id,
                    Paciente_Id = ed.Paciente_Id,
                    Fecha = ed.Fecha,
                    Enfermedad_Nombre = enfermedades.SingleOrDefault(e =>
                        e.Id == enfermedad.Enfermedad_Id
                    ).Nombre

                };
            }).ToList();

            return diagnosticos;
        }

        public async Task<DataCollection<EspecialidadDto>> GetAllEspecialidadesAsync(int page, int take)
        {
            var collection = await _context.Especialidades
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<EspecialidadDto>>();
        }

        public async Task<DataCollection<PreguntaDto>> GetAllPreguntasAsync(int? espId, int page, int take)
        {
            var collection = await _context.Preguntas
                .Include(x => x.Opciones)
                .Where(x => espId == null || x.Especialidad_Id == espId)
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<PreguntaDto>>();
        }

        public async Task<DiagnosticoDto> GetAsync(int id)
        {
            var diagnosticos = _context.Diagnosticos
                .Include(x => x.PosiblesEnfermedades)
                .Include(x => x.DetallesDiagnostico);

            var enfermedades = _context.Enfermedades;

            try
            {
                var diagnostico = await diagnosticos.SingleAsync(x => x.Id == id);

                var diagnosticoDto = diagnostico.Adapt<DiagnosticoDto>();
                diagnosticoDto.PosiblesEnfermedades = diagnosticoDto.PosiblesEnfermedades
                    .Select(pe => new PosibleEnfermedadDto
                    {
                        Id = pe.Id,
                        Porcentaje = pe.Porcentaje,
                        Enfermedad_Id = pe.Enfermedad_Id,
                        Enfermedad_Nombre = enfermedades.SingleOrDefault(e => e.Id == pe.Enfermedad_Id).Nombre
                    }).ToList();

                return diagnosticoDto;
            }
            catch (InvalidOperationException)
            {
                throw new DiagnosticosGetDiagnosticoException($"No se ha encontrado el diagnostico con Id {id}");
            }
        }

        public async Task<ResultadoDiagnosticoDto> GetResultadoAsync(int id)
        {
            var diagnosticos = _context.Diagnosticos
                .Include(x => x.PosiblesEnfermedades);
            var enfermedades = _context.Enfermedades;

            var diagnostico = await diagnosticos.SingleAsync(x => x.Id == id);
            var diagnosticoDto = diagnostico.Adapt<ResultadoDiagnosticoDto>();

            try
            {
                diagnosticoDto.PosiblesEnfermedades = diagnosticoDto.PosiblesEnfermedades
                    .Select(pe => new PosibleEnfermedadDto
                    {
                        Id = pe.Id,
                        Porcentaje = pe.Porcentaje,
                        Enfermedad_Id = pe.Enfermedad_Id,
                        Enfermedad_Nombre = enfermedades.SingleOrDefault(e => e.Id == pe.Enfermedad_Id).Nombre
                    }).ToList();
            }
            catch (InvalidOperationException)
            {
                throw new DiagnosticosGetDiagnosticoException($"No se ha encontrado el diagnostico con Id {id}");
            }

            return diagnosticoDto;
        }
    }
}
