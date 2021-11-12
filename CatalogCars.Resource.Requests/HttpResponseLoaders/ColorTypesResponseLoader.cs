using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class ColorTypesResponseLoader : BaseResponseLoader
    {
        private readonly ColorTypesClient _client;

        public ColorTypesResponseLoader()
        {
            _client = new ColorTypesClient();
        }

        public async Task<Stream> GetStreamFromGetCountColorTypesResponseAsync(ColorTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountColorTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesColorTypesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesColorTypesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetColorTypesResponseAsync(ColorTypesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetColorTypesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsColorTypeResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsColorTypeAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetColorTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetColorTypeAsync(id));
        }

        public async Task<Stream> GetStreamFromAddColorTypeResponseAsync(ColorType colorType)
        {
            return await GetStreamFromResponseAsync(await _client.AddColorTypeAsync(colorType));
        }

        public async Task<Stream> GetStreamFromUpdateColorTypeResponseAsync(ColorType colorType)
        {
            return await GetStreamFromResponseAsync(await _client.UpdateColorTypeAsync(colorType));
        }

        public async Task<Stream> GetStreamFromDeleteColorTypeResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeleteColorTypeAsync(id));
        }
    }
}
