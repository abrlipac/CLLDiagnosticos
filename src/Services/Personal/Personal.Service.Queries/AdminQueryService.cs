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
    public interface IAdminQueryService
    {
        Task<DataCollection<AdminDto>> GetAllAsync(string dni, int page, int take, IEnumerable<int> ids = null);
        Task<AdminDto> GetAsync(int id);
    }

    public class AdminQueryService : IAdminQueryService
    {
        private readonly ApplicationDbContext Context;

        public AdminQueryService(
            ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<DataCollection<AdminDto>> GetAllAsync(string dni, int page, int take, IEnumerable<int> ids = null) 
        {
            var collection = await Context.Administradores
                .Where(x => dni == null || x.Dni == dni)
                .Where(x => ids == null || ids.Contains(x.Id))
                .OrderByDescending(x => x.Id)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<AdminDto>>();
        }

        public async Task<AdminDto> GetAsync(int id)
        {
            return (await Context.Administradores.SingleAsync(x => x.Id == id)).MapTo<AdminDto>();
        }
    }
}
