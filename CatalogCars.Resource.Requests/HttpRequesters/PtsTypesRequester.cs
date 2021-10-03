using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class PtsTypesRequester
    {
        private readonly PtsTypesResponseLoader _responseLoader;

        public PtsTypesRequester()
        {
            _responseLoader = new PtsTypesResponseLoader();
        }

        public async Task<int> GetCountPtsTypesAsync(PtsTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountPtsTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesPtsTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesPtsTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<PtsType[]> GetPtsTypesAsync(PtsTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPtsTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PtsType[]>(await stream.ReadToEndAsync());
                }
            }

            return new PtsType[0];
        }
    }
}
