using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.ParseWorkers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatalogCars.Model.Tests.Parsers.AutoRu.ParseWorkers
{
    public class PaginationParseWorkerTests
    {
        private readonly PaginationParseWorker _paginationParseWorker;

        public PaginationParseWorkerTests()
        {
            _paginationParseWorker = new PaginationParseWorker();
        }

        [Fact]
        public async Task GetCarsPagination_WithParams_NotBeNullResult()
        {
            var result = await _paginationParseWorker.GetCarsPagination(new RangeMileage(30000, 0), new RangePrice(300000, 0), 1);

            result.Should().NotBeNull();
        }
    }
}
