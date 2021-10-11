using CatalogCars.Model.Database.Repositories.Default.Abstract;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFConfigurationsRepository : IConfigurationsRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFConfigurationsRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public int GetMaxDoorsCount()
        {
            return _context.Configurations
                .Max(configuration => configuration.DoorsCount);
        }

        public double? GetMaxTrunkVolumeMax()
        {
            return _context.Configurations
                .Max(configuration => configuration.TrunkVolumeMax);
        }

        public double? GetMaxTrunkVolumeMin()
        {
            return _context.Configurations
                .Max(configuration => configuration.TrunkVolumeMin);
        }

        public int GetMinDoorsCount()
        {
            return _context.Configurations
                .Min(configuration => configuration.DoorsCount);
        }

        public double? GetMinTrunkVolumeMax()
        {
            return _context.Configurations
                .Min(configuration => configuration.TrunkVolumeMax);
        }

        public double? GetMinTrunkVolumeMin()
        {
            return _context.Configurations
                .Min(configuration => configuration.TrunkVolumeMin);
        }
    }
}
