using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HttpRequesters
{
    public class SellersRequester
    {
        private readonly SellersResponseLoader _responseLoader;

        public SellersRequester()
        {
            _responseLoader = new SellersResponseLoader();
        }

        public async Task<int> GetCountSellersAsync(SellersFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetCountSellersResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<int>(await stream.ReadToEndAsync());
                }
            }

            return 0;
        }

        public async Task<string[]> GetNamesSellersAsync(string searchString)
        {
            var resultStream = await _responseLoader.GetStreamFromGetNamesSellersResponseAsync(searchString);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<string[]>(await stream.ReadToEndAsync());
                }
            }

            return new string[0];
        }

        public async Task<Seller[]> GetSellersAsync(SellersFilters filters)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSellersResponseAsync(filters);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Seller[]>(await stream.ReadToEndAsync());
                }
            }

            return new Seller[0];
        }
    }
}
