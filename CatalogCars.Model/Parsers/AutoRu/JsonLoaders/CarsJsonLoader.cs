using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.HttpClients;
using CatalogCars.Model.Parsers.AutoRu.Types;
using System.Threading.Tasks;

namespace CatalogCars.Model.Parsers.AutoRu.JsonLoaders
{
    public class CarsJsonLoader
    {
        private readonly CarsHttpClient _httpClient;

        public CarsJsonLoader()
        {
            _httpClient = new CarsHttpClient();
        }

        public async Task<string> GetCountCars(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice, int topDays, int numberPage)
        {
            var response = await _httpClient.GetCountCars(headers, rangeMileage, rangePrice, topDays, numberPage);

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<string> GetCars(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice, int topDays, int numberPage)
        {
            var response = await _httpClient.GetCars(headers, rangeMileage, rangePrice, topDays, numberPage);

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<string> GetPriceRanges(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice, int topDays, int numberPage)
        {
            var response = await _httpClient.GetPriceRanges(headers, rangeMileage, rangePrice, topDays, numberPage);

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }
    }
}
