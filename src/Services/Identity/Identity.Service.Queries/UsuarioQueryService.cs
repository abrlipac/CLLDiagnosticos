using Identity.Persistence.Database;
using Identity.Service.Queries.DTOs;
using Identity.Service.Queries.Responses;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Service.Queries
{
    public interface IUsuarioQueryService
    {
        Task<DataCollection<UsuarioDto>> GetAllAsync(int page, int take, IEnumerable<string> users = null);
        Task<Result> GetAsync(string userName);
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
                .Where(x => users == null || users.Contains(x.Id.ToString()))
                .OrderBy(x => x.NombreCompleto)
                .GetPagedAsync(page, take);

            return collection.Adapt<DataCollection<UsuarioDto>>();
        }

        public async Task<Result> GetAsync(string userName)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName);
            if (user == null)
                return new Result
                {
                    Succeed = false,
                    Error = "No se encontró al usuario",
                };

            return new Result
            {
                Succeed = true,
                Usuario = user.Adapt<UsuarioDto>()
            };
        }
    }
}
