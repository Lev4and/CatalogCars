using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PtsType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPtsTypesRepository : IPtsTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IPtsTypesSorter> _sorters;

        public EFPtsTypesRepository(CatalogCarsDbContext context, IEnumerable<IPtsTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountPtsTypes(PtsTypesFilters filters)
        {
            return _context.PtsTypes
                .Where(ptsType => EF.Functions.Like(ptsType.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesPtsTypes(string searchString)
        {
            return _context.PtsTypes
                .Where(ptsType => EF.Functions.Like(ptsType.RuName, $"%{searchString}%"))
                .OrderBy(ptsType => ptsType.RuName)
                .Select(ptsType => ptsType.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<PtsType> GetPtsTypes(PtsTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<PtsType> ptsTypes = _context.PtsTypes
                .Where(ptsType => EF.Functions.Like(ptsType.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                ptsTypes = sorter.Sort(ptsTypes);
            }

            return ptsTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
