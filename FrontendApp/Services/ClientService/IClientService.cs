
using System.Threading.Tasks;

namespace FrontendApp.Services.ClientService
{
    public interface IClientService
    {
        Task<T> GetAsync<T>(string endPoint);
    }
}
