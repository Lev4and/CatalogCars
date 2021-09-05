using CatalogCars.Model.Converters.AutoRu;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpClients
{
    public class ImportClient : BaseHttpClient
    {
        public ImportClient() : base("import/")
        {

        }

        public async Task<HttpResponseMessage> SaveAnnouncementAsync(Announcement announcement)
        {
            return await _client.PostAsync("index", new StringContent(JsonConvert.SerializeObject(announcement),
                Encoding.UTF8, "application/json"));
        }
    }
}
