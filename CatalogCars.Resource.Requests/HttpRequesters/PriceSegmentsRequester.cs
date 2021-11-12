using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class PriceSegmentsRequester
    {
        private readonly PriceSegmentsResponseLoader _responseLoader;

        public PriceSegmentsRequester()
        {
            _responseLoader = new PriceSegmentsResponseLoader();
        }

        public async Task<int> GetCountPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountPriceSegmentsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesPriceSegmentsAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesPriceSegmentsResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<PriceSegment[]> GetPriceSegmentsAsync(PriceSegmentsFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPriceSegmentsResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PriceSegment[]>(await stream.ReadToEndAsync());
                }
            }

            return new PriceSegment[0];
        }

        public async Task<PriceSegment[]> GetPriceSegmentsAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetPriceSegmentsResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PriceSegment[]>(await stream.ReadToEndAsync());
                }
            }

            return new PriceSegment[0];
        }

        public async Task<bool> ContainsPriceSegmentAsync(string name, string ruName)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsPriceSegmentResponseAsync(name, ruName);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<PriceSegment> GetPriceSegmentAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetPriceSegmentResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<PriceSegment>(await stream.ReadToEndAsync());
                }
            }

            return new PriceSegment();
        }

        public async Task<SaveResult<object>> AddPriceSegmentAsync(PriceSegment priceSegment)
        {
            var resultStream = await _responseLoader.GetStreamFromAddPriceSegmentResponseAsync(priceSegment);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdatePriceSegmentAsync(PriceSegment priceSegment)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdatePriceSegmentResponseAsync(priceSegment);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeletePriceSegmentAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeletePriceSegmentResponseAsync(id);
        }
    }
}
