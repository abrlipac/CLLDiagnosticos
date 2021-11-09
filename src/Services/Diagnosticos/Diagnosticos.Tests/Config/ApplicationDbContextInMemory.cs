using Diagnosticos.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Diagnosticos.Tests.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static ApplicationDbContext Get() 
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"Diagnosticos.Db")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
