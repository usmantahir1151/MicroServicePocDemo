using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontendApp.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly string _baseUrl;

        public ClientService(IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("ApiBaseUrl");
        }

        public async Task<T> GetAsync<T>(string endPoint)
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"{_baseUrl}{endPoint}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<T> PostAsync<T>(string endPoint, object model)
        {
            var client = new HttpClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_baseUrl}{endPoint}", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }



    }
}
