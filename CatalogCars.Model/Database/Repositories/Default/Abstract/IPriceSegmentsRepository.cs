using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPriceSegmentsRepository
    {
        IQueryable<PriceSegment> GetPriceSegments();
    }
}
