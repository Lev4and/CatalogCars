using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Option;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFOptionsRepository : IOptionsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IOptionsSorter> _sorters;

        public EFOptionsRepository(CatalogCarsDbContext context, IEnumerable<IOptionsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountOptions(OptionsFilters filters)
        {
            return _context.Options
                .Where(option => EF.Functions.Like(option.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesOptions(string searchString)
        {
            return _context.Options
                .Where(option => EF.Functions.Like(option.RuName, $"%{searchString}%"))
                .OrderBy(option => option.RuName)
                .Select(option => option.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Option> GetOptions(OptionsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Option> options = _context.Options
                .Where(option => EF.Functions.Like(option.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                options = sorter.Sort(options);
            }

            return options
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
