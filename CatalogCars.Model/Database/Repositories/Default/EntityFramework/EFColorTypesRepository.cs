using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.ColorType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFColorTypesRepository : IColorTypesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IColorTypesSorter> _sorters;

        public EFColorTypesRepository(CatalogCarsDbContext context, IEnumerable<IColorTypesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public IQueryable<ColorType> GetColorTypes(ColorTypesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<ColorType> colorTypes = _context.ColorTypes
                .Where(colorType => EF.Functions.Like(colorType.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                colorTypes = sorter.Sort(colorTypes);
            }

            return colorTypes
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public int GetCountColorTypes(ColorTypesFilters filters)
        {
            return _context.ColorTypes
                .Where(colorType => EF.Functions.Like(colorType.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesColorTypes(string searchString)
        {
            return _context.ColorTypes
                .Where(colorType => EF.Functions.Like(colorType.RuName, $"%{searchString}%"))
                .OrderBy(colorType => colorType.RuName)
                .Select(colorType => colorType.RuName)
                .Take(5)
                .AsNoTracking();
        }
    }
}
