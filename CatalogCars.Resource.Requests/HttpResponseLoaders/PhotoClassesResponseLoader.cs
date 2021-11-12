using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpClients;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpResponseLoaders
{
    public class PhotoClassesResponseLoader : BaseResponseLoader
    {
        private readonly PhotoClassesClient _client;

        public PhotoClassesResponseLoader()
        {
            _client = new PhotoClassesClient();
        }

        public async Task<Stream> GetStreamFromGetCountPhotoClassesResponseAsync(PhotoClassesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetCountPhotoClassesAsync(filters));
        }

        public async Task<Stream> GetStreamFromGetNamesPhotoClassesResponseAsync(string searchString)
        {
            return await GetStreamFromResponseAsync(await _client.GetNamesPhotoClassesAsync(searchString));
        }

        public async Task<Stream> GetStreamFromGetPhotoClassesResponseAsync(PhotoClassesFilters filters)
        {
            return await GetStreamFromResponseAsync(await _client.GetPhotoClassesAsync(filters));
        }

        public async Task<Stream> GetStreamFromContainsPhotoClassResponseAsync(string name, string ruName)
        {
            return await GetStreamFromResponseAsync(await _client.ContainsPhotoClassAsync(name, ruName));
        }

        public async Task<Stream> GetStreamFromGetPhotoClassResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.GetPhotoClassAsync(id));
        }

        public async Task<Stream> GetStreamFromAddPhotoClassResponseAsync(PhotoClass PhotoClass)
        {
            return await GetStreamFromResponseAsync(await _client.AddPhotoClassAsync(PhotoClass));
        }

        public async Task<Stream> GetStreamFromUpdatePhotoClassResponseAsync(PhotoClass PhotoClass)
        {
            return await GetStreamFromResponseAsync(await _client.UpdatePhotoClassAsync(PhotoClass));
        }

        public async Task<Stream> GetStreamFromDeletePhotoClassResponseAsync(Guid id)
        {
            return await GetStreamFromResponseAsync(await _client.DeletePhotoClassAsync(id));
        }
    }
}
