using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.CookieWorkers;
using CatalogCars.Model.Parsers.AutoRu.JsonWorkers;
using CatalogCars.Model.Parsers.AutoRu.ParseWorkers;
using CatalogCars.Model.Parsers.AutoRu.Types;
using FluentAssertions;
using Newtonsoft.Json;
using System;
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
            var headers = await _cookieWorker.GetHeadersAjaxRequestForCars(new RangeMileage(30000, 0), new RangePrice(300000, 0), 1, 1, 1);
            var cars = await _jsonWorker.GetCars(headers, new RangeMileage(30000, 0), new RangePrice(300000, 0), 95, 1, 1);

            cars.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAllCars_WithParams_ReturnNotNullResult()
        {
            var topDays = 5;
            var pageSize = 100;
            var priceIncrement = 50000;
            var mileageIncrement = 50000;

            for (int i = 1900000; i <= 300000000; i += priceIncrement)
            {
                if(i >= 900000)
                {
                    if(i >= 3000000)
                    {
                        if(i >= 10000000)
                        {
                            priceIncrement = 10000000;
                        }
                        else
                        {
                            priceIncrement = 5000000;
                        }
                    }
                    else
                    {
                        priceIncrement = 100000;
                    }
                }

                for(int j = 0; j < 1100000; j += mileageIncrement)
                {
                    if(j >= 300000)
                    {
                        mileageIncrement = 800000;
                    }
                    else
                    {
                        mileageIncrement = 50000;
                    }

                    var rangePrice = new RangePrice(i + priceIncrement - 1, i);
                    var rangeMileage = new RangeMileage(j + mileageIncrement - 1, j);

                    var headers = await _cookieWorker.GetHeadersAjaxRequestForCars(rangeMileage, rangePrice, 1, topDays, 1);

                    int maxNumberPage = Convert.ToInt32(JsonConvert.DeserializeObject<dynamic>((await _jsonWorker.GetCars(headers, 
                        rangeMileage, rangePrice, pageSize, topDays, 1))).pagination.total_page_count);

                    for (int z = 1; z <= maxNumberPage; z++)
                    {
                        File.WriteAllText($"Cars/from 2021-09-21 to 2021-09-26/Price from {i} to {i + priceIncrement - 1} Mileage from {j} to {j + mileageIncrement - 1} Page {z}.json", 
                            await _jsonWorker.GetCars(headers, rangeMileage, rangePrice, pageSize, topDays, z));
                    }
                }
            }
        }
    }
}
