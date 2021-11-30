using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.Repositories.GlobalConfigurationRepository;
using SharedComponent.ViewModels.Configurations;
using System.Collections.Generic;

namespace MicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;
        private readonly IGlobalConfigurationRepository _repository;

        public ConfigurationController(ILogger<ConfigurationController> logger, IGlobalConfigurationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(nameof(GetConfigurations))]
        public IEnumerable<GlobalConfigurationVM> GetConfigurations()
        {
            _logger.LogInformation($"{nameof(GetConfigurations)} method running");
            return _repository.GetConfigurations();
        }
    }
}
