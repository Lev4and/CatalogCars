using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class ConfigurationsClient : BaseHttpClient
    {
        public ConfigurationsClient() : base("configurations/")
        {

        }

        public async Task<HttpResponseMessage> GetMaxDoorsCountAsync()
        {
            return await _client.PostAsync("maxDoorsCount", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxTrunkVolumeMaxAsync()
        {
            return await _client.PostAsync("maxTrunkVolumeMax", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxTrunkVolumeMinAsync()
        {
            return await _client.PostAsync("maxTrunkVolumeMin", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinDoorsCountAsync()
        {
            return await _client.PostAsync("minDoorsCount", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinTrunkVolumeMaxAsync()
        {
            return await _client.PostAsync("minTrunkVolumeMax", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinTrunkVolumeMinAsync()
        {
            return await _client.PostAsync("minTrunkVolumeMin", new StringContent("", Encoding.UTF8, "application/json"));
        }
    }
}
