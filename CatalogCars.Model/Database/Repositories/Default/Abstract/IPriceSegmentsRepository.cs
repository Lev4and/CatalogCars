using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPriceSegmentsRepository
    {
        int GetCountPriceSegments(PriceSegmentsFilters filters);

        IQueryable<string> GetNamesPriceSegments(string searchString);

        IQueryable<PriceSegment> GetPriceSegments();

        IQueryable<PriceSegment> GetPriceSegments(PriceSegmentsFilters filters);
    }
}
