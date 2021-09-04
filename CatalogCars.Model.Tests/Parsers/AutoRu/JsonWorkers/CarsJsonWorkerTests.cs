using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.CookieWorkers;
using CatalogCars.Model.Parsers.AutoRu.JsonWorkers;
using CatalogCars.Model.Parsers.AutoRu.ParseWorkers;
using FluentAssertions;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CatalogCars.Model.Tests.Parsers.AutoRu.JsonWorkers
{
    public class CarsJsonWorkerTests
    {
        private readonly PaginationParseWorker _paginationParseWorker;

        private readonly CarsCookieWorker _cookieWorker;
        private readonly CarsJsonWorker _jsonWorker;

        public CarsJsonWorkerTests()
        {
            _paginationParseWorker = new PaginationParseWorker();

            _cookieWorker = new CarsCookieWorker();
            _jsonWorker = new CarsJsonWorker();
        }

        [Fact]
        public async Task GetCars_WithParams_ReturnNotNullResult()
        {
            var headers = await _cookieWorker.GetHeadersAjaxRequestForCars(new RangeMileage(30000, 0), new RangePrice(300000, 0), 1, 1);
            var cars = await _jsonWorker.GetCars(headers, new RangeMileage(30000, 0), new RangePrice(300000, 0), 1, 1);

            cars.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAllCars_WithParams_ReturnNotNullResult()
        {
            var priceIncrement = 10000000;
            var mileageIncrement = 5000000;

            for (int i = 3000000; i <= 300000000; i += priceIncrement)
            {
                for(int j = 0; j < 1100000; j += mileageIncrement)
                {
                    var rangePrice = new RangePrice(i + priceIncrement - 1, i);
                    var rangeMileage = new RangeMileage(j + mileageIncrement - 1, j);

                    var pagination = await _paginationParseWorker.GetCarsPagination(rangeMileage, rangePrice, 1, 1);
                    var headers = await _cookieWorker.GetHeadersAjaxRequestForCars(rangeMileage, rangePrice, 1, 1);

                    for (int z = 1; z <= pagination.MaxNumberPage; z++)
                    {
                        File.WriteAllText($"Cars/from 2021-08-29 to 2021-08-31/Price from {i} to {i + priceIncrement - 1} Mileage from {j} to {j + mileageIncrement - 1} Page {z}.json", 
                            await _jsonWorker.GetCars(headers, rangeMileage, rangePrice, 1, z));
                    }
                }
            }
        }
    }
}
