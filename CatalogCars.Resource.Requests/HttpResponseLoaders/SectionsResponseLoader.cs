using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
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

        public async Task<Stream> GetStreamFromContainsSectionResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsSectionAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetSectionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetSectionAsync(id));
        }

        public async Task<Stream> GetStreamFromAddSectionResponseAsync(Section section)
        {
            return await GetStreamFromResponseAsync(await _client.AddSectionAsync(section));
        }

        public async Task<Stream> GetStreamFromUpdateSectionResponseAsync(Section section)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateSectionAsync(section));
        }

        public async Task<Stream> GetStreamFromDeleteSectionResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteSectionAsync(id));
        }
    }
}
