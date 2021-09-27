using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Color;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFColorsRepository : IColorsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IColorsSorter> _sorters;

        public EFColorsRepository(CatalogCarsDbContext context, IEnumerable<IColorsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public IQueryable<Color> GetColors(ColorsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Color> colors = _context.Colors
                .Where(color => EF.Functions.Like(color.Value, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                colors = sorter.Sort(colors);
            }

            return colors
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public int GetCountColors(ColorsFilters filters)
        {
            return _context.Colors
                .Where(color => EF.Functions.Like(color.Value, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesColors(string searchString)
        {
            return _context.Colors
                .Where(color => EF.Functions.Like(color.Value, $"%{searchString}%"))
                .OrderBy(color => color.Value)
                .Select(color => color.Value)
                .Take(5)
                .AsNoTracking();
        }
    }
}
