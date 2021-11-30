using Microsoft.Extensions.Logging;
using ServiceLayer.Database;
using SharedComponent.ViewModels.Configurations;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Repositories.GlobalConfigurationRepository
{
    public class GlobalConfigurationRepository : IGlobalConfigurationRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger<GlobalConfigurationRepository> _logger;
        public GlobalConfigurationRepository(ILogger<GlobalConfigurationRepository> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IEnumerable<GlobalConfigurationVM> GetConfigurations()
        {
            _logger.LogInformation($"{nameof(GetConfigurations)} method running");
            return _databaseContext.GlobalConfigurations.Select(x => new GlobalConfigurationVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedDate = x.CreatedDate
            }).ToList();
        }

    }
}
