using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.JsonLoaders;
using CatalogCars.Model.Parsers.AutoRu.Types;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CatalogCars.Model.Parsers.AutoRu.JsonWorkers
{
    public class CarsJsonWorker
    {
        private readonly CarsJsonLoader _jsonLoader;

        public CarsJsonWorker()
        {
            _jsonLoader = new CarsJsonLoader();
        }

        public async Task<string> GetCars(HeadersAjaxRequestForCars headers, RangeMileage rangeMileage, RangePrice rangePrice,  int topDays, int numberPage)
        {
            return await _jsonLoader.GetCars(headers, rangeMileage, rangePrice, topDays, numberPage);
        }
    }
}
