using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Tag;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFTagsRepository : ITagsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ITagsSorter> _sorters;

        public EFTagsRepository(CatalogCarsDbContext context, IEnumerable<ITagsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountTags(TagsFilters filters)
        {
            return _context.Tags
                .Where(tag => EF.Functions.Like(tag.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesTags(string searchString)
        {
            return _context.Tags
                .Where(tag => EF.Functions.Like(tag.RuName, $"%{searchString}%"))
                .OrderBy(tag => tag.RuName)
                .Select(tag => tag.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Tag> GetTags(TagsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Tag> tags = _context.Tags
                .Where(tag => EF.Functions.Like(tag.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                tags = sorter.Sort(tags);
            }

            return tags
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
