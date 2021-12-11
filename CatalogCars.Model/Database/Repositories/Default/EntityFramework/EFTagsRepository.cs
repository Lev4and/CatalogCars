using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Tag;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool ContainsTag(string name, string ruName)
        {
            return _context.Tags.FirstOrDefault(tag => tag.Name == name ||
                tag.RuName == ruName) != null;
        }

        public void DeleteTag(Guid id)
        {
            _context.Tags.Remove(GetTag(id));
            _context.SaveChanges();
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

        public Tag GetTag(Guid id)
        {
            return _context.Tags
                .AsNoTracking()
                .FirstOrDefault(tag => tag.Id == id);
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

        public IQueryable<Tag> GetTags()
        {
            return _context.Tags
                .OrderBy(tag => tag.RuName)
                .AsNoTracking();
        }

        public bool SaveTag(Tag tag)
        {
            if (tag.Id == default)
            {
                if (!ContainsTag(tag.Name, tag.RuName))
                {
                    _context.Entry(tag).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetTag(tag.Id);

                if (currentVersion.Name != tag.Name)
                {
                    if (!ContainsTag(tag.Name, tag.RuName))
                    {
                        _context.Entry(tag).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(tag).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
