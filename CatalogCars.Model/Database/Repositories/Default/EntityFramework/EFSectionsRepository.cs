using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Section;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFSectionsRepository : ISectionsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ISectionsSorter> _sorters;

        public EFSectionsRepository(CatalogCarsDbContext context, IEnumerable<ISectionsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountSections(SectionsFilters filters)
        {
            return _context.Sections
                .Where(section => EF.Functions.Like(section.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesSections(string searchString)
        {
            return _context.Sections
                .Where(section => EF.Functions.Like(section.RuName, $"%{searchString}%"))
                .OrderBy(section => section.RuName)
                .Select(section => section.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Section> GetSections(SectionsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Section> sections = _context.Sections
                .Where(section => EF.Functions.Like(section.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                sections = sorter.Sort(sections);
            }

            return sections
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<Section> GetSections()
        {
            return _context.Sections
                .AsNoTracking();
        }
    }
}
