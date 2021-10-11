using CatalogCars.Model.Database.Repositories.Default.Abstract;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFTechnicalParametersRepository : ITechnicalParametersRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFTechnicalParametersRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public double GetMaxAcceleration()
        {
            return _context.TechnicalParameters
                .Max(technicalParameter => technicalParameter.Acceleration);
        }

        public int GetMaxClearanceMin()
        {
            return _context.TechnicalParameters
                .Max(technicalParameter => technicalParameter.ClearanceMin);
        }

        public int GetMaxDisplacement()
        {
            return _context.TechnicalParameters
                .Max(technicalParameter => technicalParameter.Displacement);
        }

        public double? GetMaxFuelRate()
        {
            return _context.TechnicalParameters
                .Max(technicalParameter => technicalParameter.FuelRate);
        }

        public int GetMaxPower()
        {
            return _context.TechnicalParameters
                .Max(technicalParameter => technicalParameter.Power);
        }

        public int GetMaxPowerKvt()
        {
            return _context.TechnicalParameters
                .Max(technicalParameter => technicalParameter.PowerKvt);
        }

        public double GetMinAcceleration()
        {
            return _context.TechnicalParameters
                .Min(technicalParameter => technicalParameter.Acceleration);
        }

        public int GetMinClearanceMin()
        {
            return _context.TechnicalParameters
                .Min(technicalParameter => technicalParameter.ClearanceMin);
        }

        public int GetMinDisplacement()
        {
            return _context.TechnicalParameters
                .Min(technicalParameter => technicalParameter.Displacement);
        }

        public double? GetMinFuelRate()
        {
            return _context.TechnicalParameters
                .Min(technicalParameter => technicalParameter.FuelRate);
        }

        public int GetMinPower()
        {
            return _context.TechnicalParameters
                .Min(technicalParameter => technicalParameter.Power);
        }

        public int GetMinPowerKvt()
        {
            return _context.TechnicalParameters
                .Min(technicalParameter => technicalParameter.PowerKvt);
        }
    }
}
