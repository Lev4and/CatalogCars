using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class TechnicalParametersClient : BaseHttpClient
    {
        public TechnicalParametersClient() : base("technicalParameters/")
        {

        }

        public async Task<HttpResponseMessage> GetMinPowerAsync()
        {
            return await _client.PostAsync("minPower", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxPowerAsync()
        {
            return await _client.PostAsync("maxPower", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinPowerKvtAsync()
        {
            return await _client.PostAsync("minPowerKvt", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxPowerKvtAsync()
        {
            return await _client.PostAsync("maxPowerKvt", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinDisplacementAsync()
        {
            return await _client.PostAsync("minDisplacement", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxDisplacementAsync()
        {
            return await _client.PostAsync("maxDisplacement", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinClearanceMinAsync()
        {
            return await _client.PostAsync("minClearanceMin", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxClearanceMinAsync()
        {
            return await _client.PostAsync("maxClearanceMin", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinFuelRateAsync()
        {
            return await _client.PostAsync("minFuelRate", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxFuelRateAsync()
        {
            return await _client.PostAsync("maxFuelRate", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMinAccelerationAsync()
        {
            return await _client.PostAsync("minAcceleration", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxAccelerationAsync()
        {
            return await _client.PostAsync("maxAcceleration", new StringContent("", Encoding.UTF8, "application/json"));
        }
    }
}
