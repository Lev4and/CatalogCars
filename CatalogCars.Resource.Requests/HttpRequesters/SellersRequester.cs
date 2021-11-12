using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpResponseLoaders;
using Newtonsoft.Json;
using System;
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

        public async Task<bool> ContainsSellerAsync(Guid locationId)
        {
            var resultStream = await _responseLoader.GetStreamFromContainsSellerResponseAsync(locationId);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<bool>(await stream.ReadToEndAsync());
                }
            }

            return false;
        }

        public async Task<Seller> GetSellerAsync(Guid id)
        {
            var resultStream = await _responseLoader.GetStreamFromGetSellerResponseAsync(id);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<Seller>(await stream.ReadToEndAsync());
                }
            }

            return new Seller();
        }

        public async Task<SaveResult<object>> AddSellerAsync(Seller seller)
        {
            var resultStream = await _responseLoader.GetStreamFromAddSellerResponseAsync(seller);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task<SaveResult<object>> UpdateSellerAsync(Seller seller)
        {
            var resultStream = await _responseLoader.GetStreamFromUpdateSellerResponseAsync(seller);

            if (resultStream != null)
            {
                using (var stream = new StreamReader(resultStream))
                {
                    return JsonConvert.DeserializeObject<SaveResult<object>>(await stream.ReadToEndAsync());
                }
            }

            return new SaveResult<object>();
        }

        public async Task DeleteSellerAsync(Guid id)
        {
            await _responseLoader.GetStreamFromDeleteSellerResponseAsync(id);
        }
    }
}
