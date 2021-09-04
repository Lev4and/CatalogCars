using CatalogCars.Authorization.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Authorization.Requests.HttpClients
{
    public class AuthorizationClient : BaseHttpClient
    {
        public AuthorizationClient() : base("authorization/")
        {

        }

        public async Task<HttpResponseMessage> LoginAsync(LoginViewModel viewModel)
        {
            return await _client.PostAsync("login", new StringContent(JsonConvert.SerializeObject(viewModel),
                Encoding.UTF8, "application/json"));
        }
    }
}
