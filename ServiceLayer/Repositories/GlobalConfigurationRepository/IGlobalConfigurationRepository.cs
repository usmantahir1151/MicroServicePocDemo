using SharedComponent.ViewModels.Configurations;
using System.Collections.Generic;


namespace ServiceLayer.Repositories.GlobalConfigurationRepository
{
    public interface IGlobalConfigurationRepository
    {
        IEnumerable<GlobalConfigurationVM> GetConfigurations();
    }
}
