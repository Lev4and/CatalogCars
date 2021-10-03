using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
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
    }
}
