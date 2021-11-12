using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class PhotoClassesRequester
    {
        private readonly PhotoClassesResponseLoader _responseLoader;

        public PhotoClassesRequester()
        {
            _responseLoader = new PhotoClassesResponseLoader();
        }

        public async Task<int> GetCountPhotoClassesAsync(PhotoClassesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountPhotoClassesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesPhotoClassesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesPhotoClassesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<PhotoClass[]> GetPhotoClassesAsync(PhotoClassesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPhotoClassesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PhotoClass[]>(await stream.ReadToEndAsync());
                }
            }

            return new PhotoClass[0];
        }

        public async Task<bool> ContainsPhotoClassAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsPhotoClassResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<PhotoClass> GetPhotoClassAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPhotoClassResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PhotoClass>(await stream.ReadToEndAsync());
                }
            }

            return new PhotoClass();
        }

        public async Task<SaveResult<object>> AddPhotoClassAsync(PhotoClass photoClass)
        {
            var resultStream = await _responseLoader.GetStreamFromAddPhotoClassResponseAsync(photoClass);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdatePhotoClassAsync(PhotoClass photoClass)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdatePhotoClassResponseAsync(photoClass);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeletePhotoClassAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeletePhotoClassResponseAsync(id);
        }
    }
}
