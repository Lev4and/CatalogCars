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

        public async Task<List<Cookie>> GetCookies()
        {
            var response = await _httpClient.GetMainPage();

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return _httpClient.GetCookies();
                }
            }

            return new List<Cookie>();
        }

        public async Task<List<Cookie>> GetCookies(RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            var response = await _httpClient.GetCars(rangeMileage, rangePrice, pageSize, topDays, numberPage);

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return _httpClient.GetCookies(_httpClient.GetUrl(rangeMileage, rangePrice, pageSize, topDays, numberPage));
                }
            }

            return new List<Cookie>();
        }
    }
}
