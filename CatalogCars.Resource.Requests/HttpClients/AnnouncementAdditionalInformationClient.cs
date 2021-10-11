using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class AnnouncementAdditionalInformationClient : BaseHttpClient
    {
        public AnnouncementAdditionalInformationClient() : base("announcementAdditionalInformation/")
        {

        }

        public async Task<HttpResponseMessage> GetMinCreatedAtAsync()
        {
            return await _client.PostAsync("minCreatedAt", new StringContent("", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> GetMaxCreatedAtAsync()
        {
            return await _client.PostAsync("maxCreatedAt", new StringContent("", Encoding.UTF8, "application/json"));
        }
    }
}
