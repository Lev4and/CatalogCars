using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.HttpClients;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CatalogCars.Model.Parsers.AutoRu.CookieLoaders
{
    public class CarsCookieLoader
    {
        private readonly CarsHttpClient _httpClient;

        public CarsCookieLoader()
        {
            _httpClient = new CarsHttpClient();
        }

        public async Task<List<Cookie>> GetCookies(RangeMileage rangeMileage, RangePrice rangePrice, int numberPage)
        {
            var response = await _httpClient.GetCars(rangeMileage, rangePrice, numberPage);

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return _httpClient.GetCookies(_httpClient.GetUrl(rangeMileage, rangePrice, numberPage));
                }
            }

            return new List<Cookie>();
        }
    }
}
