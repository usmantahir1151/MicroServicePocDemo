using ServiceLayer.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Database
{
    public static class DatabaseContextSeed
    {
        public static async Task SeedDataAsync(DatabaseContext context)
        {
            await AddGlobalConfigurations(context);
        }
        private static async Task AddGlobalConfigurations(DatabaseContext context)
        {
            var cofigurations = context.GlobalConfigurations.ToList();
            var newCofigurations = new List<GlobalConfiguration>
            {
                new GlobalConfiguration
                {
                    Name = "Config1",
                    Description="Config1 description",
                    IsActive=true,
                    CreatedDate=DateTime.UtcNow
                },
                new GlobalConfiguration
                {
                    Name = "Config2",
                    Description="Config2 description",
                    IsActive=true,
                    CreatedDate=DateTime.UtcNow
                },
                new GlobalConfiguration
                {
                    Name = "Config3",
                    Description="Config3 description",
                    IsActive=true,
                    CreatedDate=DateTime.UtcNow
                }

            };
            var result = newCofigurations.Where(gc => cofigurations.All(newGc => !string.Equals(newGc.Name, gc.Name, StringComparison.CurrentCultureIgnoreCase)));
            await context.GlobalConfigurations.AddRangeAsync(result);
            await context.SaveChangesAsync();
        }
    }
}
