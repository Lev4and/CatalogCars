using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class MarksResponseLoader : BaseResponseLoader
    {
        private readonly MarksClient _client;

        public MarksResponseLoader()
        {
            _client = new MarksClient();
        }

        public async Task<Stream> GetStreamFromGetCountMarksResponseAsync(MarksFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountMarksAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesMarksResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesMarksAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetMarksResponseAsync(MarksFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetMarksAsync(filters));
        }
    }
}
