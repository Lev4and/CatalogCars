using CatalogCars.Model.Database.Repositories.Default.Abstract;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFStatesRepository : IStatesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFStatesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public int GetMaxMileage()
        {
            return _context.States
                .Max(state => state.Mileage);
        }

        public int GetMinMileage()
        {
            return _context.States
                .Min(state => state.Mileage);
        }
    }
}
