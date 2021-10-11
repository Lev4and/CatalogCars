using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.EngineType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFEngineTypesRepository : IEngineTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IEngineTypesSorter> _sorters;

        public EFEngineTypesRepository(CatalogCarsDbContext context, IEnumerable<IEngineTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountEngineTypes(EngineTypesFilters filters)
        {
            return _context.EngineTypes
                .Where(engineType => EF.Functions.Like(engineType.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<EngineType> GetEngineTypes(EngineTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<EngineType> engineTypes = _context.EngineTypes
                .Where(engineType => EF.Functions.Like(engineType.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                engineTypes = sorter.Sort(engineTypes);
            }

            return engineTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<EngineType> GetEngineTypes()
        {
            return _context.EngineTypes
                .AsNoTracking();
        }

        public IQueryable<string> GetNamesEngineTypes(string searchString)
        {
            return _context.EngineTypes
                .Where(engineType => EF.Functions.Like(engineType.RuName, $"%{searchString}%"))
                .OrderBy(engineType => engineType.RuName)
                .Select(engineType => engineType.RuName)
                .Take(5)
                .AsNoTracking();
        }
    }
}
