using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpClients;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class SectionsResponseLoader : BaseResponseLoader
    {
        private readonly SectionsClient _client;

        public SectionsResponseLoader()
        {
            _client = new SectionsClient();
        }

        public async Task<Stream> GetStreamFromGetCountSectionsResponseAsync(SectionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountSectionsAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesSectionsResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesSectionsAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetSectionsResponseAsync()
        {
            return await GetStreamFromResponseAsync(await _client.GetSectionsAsync());
        }

        public async Task<Stream> GetStreamFromGetSectionsResponseAsync(SectionsFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetSectionsAsync(filters));
        }
    }
}
