using Personal.Persistence.Database;
using Personal.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal.Service.Queries
{
    public interface IEmpleadoQueryService
    {
        Task<DataCollection<EmpleadoDto>> GetAllAsync(string dni, int page, int take, IEnumerable<int> empleados = null);
        Task<EmpleadoDto> GetAsync(int id);
    }

    public class EmpleadoQueryService : IEmpleadoQueryService
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<EmpleadoDto>> GetAllAsync(string dni, int page, int take, IEnumerable<int> empleados = null) 
        {
            var collection = await _context.Empleados
                .Where(x => dni == null || x.Dni == dni)
                .Where(x => empleados == null || empleados.Contains(x.Id))
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<EmpleadoDto>>();
        }

        public async Task<EmpleadoDto> GetAsync(int id)
        {
            return (await _context.Empleados.SingleAsync(x => x.Id == id)).MapTo<EmpleadoDto>();
        }
    }
}
