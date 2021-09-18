using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPriceSegmentsRepository : IPriceSegmentsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFPriceSegmentsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public IQueryable<PriceSegment> GetPriceSegments()
        {
            return _context.PriceSegments
                .OrderBy(priceSegment => priceSegment.Name)
                .AsNoTracking();
        }
    }
}
