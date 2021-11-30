using Microsoft.EntityFrameworkCore;
using ServiceLayer.Database.Entities;

namespace ServiceLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<GlobalConfiguration> GlobalConfigurations { get; set; }
    }
}
