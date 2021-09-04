using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.HttpClients;
using CatalogCars.Model.Parsers.AutoRu.Types;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.Model.Parsers.AutoRu.HtmlLoaders
{
    public class CarsHtmlLoader
    {
        private readonly CarsHttpClient _httpClient;

        public CarsHtmlLoader()
        {
            _httpClient = new CarsHttpClient();
        }

        public async Task<string> GetCars(RangeMileage rangeMileage, RangePrice rangePrice,  int topDays, int numberPage)
        {
            var response = await _httpClient.GetCars(rangeMileage, rangePrice, topDays, numberPage);

            if(response != null)
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
