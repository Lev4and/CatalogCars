using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPriceSegmentsRepository
    {
        bool ContainsPriceSegment(string name, string ruName);

        bool SavePriceSegment(PriceSegment priceSegment);

        int GetCountPriceSegments(PriceSegmentsFilters filters);

        PriceSegment GetPriceSegment(Guid id);

        IQueryable<string> GetNamesPriceSegments(string searchString);

        IQueryable<PriceSegment> GetPriceSegments();

        IQueryable<PriceSegment> GetPriceSegments(PriceSegmentsFilters filters);

        void DeletePriceSegment(Guid id);
    }
}
