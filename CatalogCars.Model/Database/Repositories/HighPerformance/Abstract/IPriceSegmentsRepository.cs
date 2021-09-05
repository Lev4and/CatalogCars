using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPriceSegmentsRepository
    {
        bool Contains(string name);

        bool Save(ref PriceSegment entity);

        Guid GetPriceSegmentId(string name);
    }
}
