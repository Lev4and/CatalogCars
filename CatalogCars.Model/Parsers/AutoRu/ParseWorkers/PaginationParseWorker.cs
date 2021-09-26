using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.HtmlLoaders;
using CatalogCars.Model.Parsers.AutoRu.Types;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogCars.Model.Parsers.AutoRu.ParseWorkers
{
    public class PaginationParseWorker : BaseParseWorker
    {
        private readonly PaginationParser _parser;
        private readonly CarsHtmlLoader _htmlLoader;

        public PaginationParseWorker() : base()
        {
            _parser = new PaginationParser();
            _htmlLoader = new CarsHtmlLoader();
        }

        public async Task<CarsPagination> GetCarsPagination(RangeMileage rangeMileage, RangePrice rangePrice, int pageSize, int topDays, int numberPage)
        {
            var resultHtml = await _htmlLoader.GetCars(rangeMileage, rangePrice, pageSize, topDays, numberPage);
            var document = await _htmlParser.ParseDocumentAsync(resultHtml, new CancellationTokenSource().Token);

            return _parser.Parse(document);
        }
    }
}
