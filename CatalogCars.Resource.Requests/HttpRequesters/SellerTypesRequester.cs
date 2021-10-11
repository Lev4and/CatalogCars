using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class SellerTypesRequester
    {
        private readonly SellerTypesResponseLoader _responseLoader;

        public SellerTypesRequester()
        {
            _responseLoader = new SellerTypesResponseLoader();
        }

        public async Task<int> GetCountSellerTypesAsync(SellerTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountSellerTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesSellerTypesAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesSellerTypesResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<SellerType[]> GetSellerTypesAsync()
        {
            var resultStream = await _responseLoader.GetStreamFromGetSellerTypesResponseAsync();

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SellerType[]>(await stream.ReadToEndAsync());
                }
            }

            return new SellerType[0];
        }

        public async Task<SellerType[]> GetSellerTypesAsync(SellerTypesFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSellerTypesResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SellerType[]>(await stream.ReadToEndAsync());
                }
            }

            return new SellerType[0];
        }
    }
}
