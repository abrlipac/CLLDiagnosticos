using Clientes.Persistence.Database;
using Clientes.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Service.Queries
{
    public interface IPacienteQueryService
    {
        Task<DataCollection<PacienteDto>> GetAllAsync(string dni, int page, int take, IEnumerable<int> pacientes = null);
        Task<PacienteDto> GetAsync(int id);
    }

    public class PacienteQueryService : IPacienteQueryService
    {
        private readonly ApplicationDbContext _context;

        public PacienteQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<PacienteDto>> GetAllAsync(string dni, int page, int take, IEnumerable<int> pacientes = null) 
        {
            var collection = await _context.Pacientes
                .Where(x => dni == null || x.Dni == dni)
                .Where(x => pacientes == null || pacientes.Contains(x.Id))
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<PacienteDto>>();
        }

        public async Task<PacienteDto> GetAsync(int id)
        {
            try
            {
                return (await _context.Pacientes.SingleAsync(x => x.Id == id)).MapTo<PacienteDto>();
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
    }
}
