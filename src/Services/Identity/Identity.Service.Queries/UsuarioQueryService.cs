using Identity.Persistence.Database;
using Identity.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Service.Queries
{
    public interface IUsuarioQueryService
    {
        Task<DataCollection<UsuarioDto>> GetAllAsync(int page, int take, IEnumerable<string> users = null);
        Task<UsuarioDto> GetAsync(string id);
    }
    public class UsuarioQueryService : IUsuarioQueryService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioQueryService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<UsuarioDto>> GetAllAsync(int page, int take, IEnumerable<string> users = null)
        {
            var collection = await _context.Users
                .Where(x => users == null || users.Contains(x.Id))
                .OrderBy(x => x.NombreCompleto)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<UsuarioDto>>();
        }

        public async Task<UsuarioDto> GetAsync(string id)
        {
            return (await _context.Users.SingleAsync(x => x.Id == id)).MapTo<UsuarioDto>();
        }
    }
}
