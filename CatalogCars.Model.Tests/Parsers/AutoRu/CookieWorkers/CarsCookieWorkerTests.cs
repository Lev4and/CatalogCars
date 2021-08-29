using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.CookieWorkers;
using System.Threading.Tasks;
using Xunit;

namespace CatalogCars.Model.Tests.Parsers.AutoRu.CookieWorkers
{
    public class CarsCookieWorkerTests
    {
        private readonly CarsCookieWorker _cookieWorker;

        public CarsCookieWorkerTests()
        {
            _cookieWorker = new CarsCookieWorker();
        }

        [Fact]
        public async Task GetHeadersAjaxRequestForCars_WithParams_ReturnNotNullGetHeadersAjaxRequestForCars()
        {
            await _cookieWorker.GetHeadersAjaxRequestForCars(new RangeMileage(30000, 0), new RangePrice(300000, 0), 1);
        }
    }
}
