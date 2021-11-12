using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class RegionsRequester
    {
        private readonly RegionsResponseLoader _responseLoader;

        public RegionsRequester()
        {
            _responseLoader = new RegionsResponseLoader();
        }

        public async Task<int> GetCountRegionsAsync(RegionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountRegionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesRegionsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesRegionsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<RegionInformation[]> GetRegionsAsync(RegionsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetRegionsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<RegionInformation[]>(await stream.ReadToEndAsync());
                }
            }

            return new RegionInformation[0];
        }

        public async Task<bool> ContainsRegionAsync(string stringId)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsRegionResponseAsync(stringId);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<RegionInformation> GetRegionAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetRegionResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<RegionInformation>(await stream.ReadToEndAsync());
                }
            }

            return new RegionInformation();
        }

        public async Task<SaveResult<object>> AddRegionAsync(RegionInformation region)
        {
            var resultStream = await _responseLoader.GetStreamFromAddRegionResponseAsync(region);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateRegionAsync(RegionInformation region)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateRegionResponseAsync(region);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteRegionAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteRegionResponseAsync(id);
        }
    }
}
