using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.GearType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFGearTypesRepository : IGearTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IGearTypesSorter> _sorters;

        public EFGearTypesRepository(CatalogCarsDbContext context, IEnumerable<IGearTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountGearTypes(GearTypesFilters filters)
        {
            return _context.GearTypes
                .Where(gearType => EF.Functions.Like(gearType.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<GearType> GetGearTypes(GearTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<GearType> gearTypes = _context.GearTypes
                .Where(gearType => EF.Functions.Like(gearType.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                gearTypes = sorter.Sort(gearTypes);
            }

            return gearTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<GearType> GetGearTypes()
        {
            return _context.GearTypes
                .AsNoTracking();
        }

        public IQueryable<string> GetNamesGearTypes(string searchString)
        {
            return _context.GearTypes
                .Where(gearType => EF.Functions.Like(gearType.RuName, $"%{searchString}%"))
                .OrderBy(gearType => gearType.RuName)
                .Select(gearType => gearType.RuName)
                .Take(5)
                .AsNoTracking();
        }
    }
}
