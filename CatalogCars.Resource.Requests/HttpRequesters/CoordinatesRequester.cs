using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class CoordinatesRequester
    {
        private readonly CoordinatesResponseLoader _responseLoader;

        public CoordinatesRequester()
        {
            _responseLoader = new CoordinatesResponseLoader();
        }

        public async Task<int> GetCountCoordinatesAsync(CoordinatesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountCoordinatesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesCoordinatesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesCoordinatesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Coordinate[]> GetCoordinatesAsync(CoordinatesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCoordinatesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Coordinate[]>(await stream.ReadToEndAsync());
                }
            }

            return new Coordinate[0];
        }
    }
}
