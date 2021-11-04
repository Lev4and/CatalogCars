using CatalogCars.Model.Database.Repositories.Default.Abstract;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPtsRepository : IPtsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFPtsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public int? GetMaxOwnersNumber()
        {
            return _context.Pts
                .Max(pts => pts.OwnersNumber);
        }

        public int? GetMaxYear()
        {
            return _context.Pts
                .Max(pts => pts.Year);
        }

        public int? GetMinOwnersNumber()
        {
            return _context.Pts
                .Min(pts => pts.OwnersNumber);
        }

        public int? GetMinYear()
        {
            return _context.Pts
                .Min(pts => pts.Year);
        }
    }
}
