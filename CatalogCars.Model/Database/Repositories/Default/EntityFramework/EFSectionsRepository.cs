using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Section;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool ContainsSection(string name, string ruName)
        {
            return _context.Sections.FirstOrDefault(section => section.Name == name ||
                section.RuName == ruName) != null;
        }

        public void DeleteSection(Guid id)
        {
            _context.Sections.Remove(GetSection(id));
            _context.SaveChanges();
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

        public Section GetSection(Guid id)
        {
            return _context.Sections.FirstOrDefault(section => section.Id == id);
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

        public bool SaveSection(Section section)
        {
            if (section.Id == default)
            {
                if (!ContainsSection(section.Name, section.RuName))
                {
                    _context.Entry(section).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetSection(section.Id);

                if (currentVersion.Name != section.Name || currentVersion.RuName != section.RuName)
                {
                    if (!ContainsSection(section.Name, section.RuName))
                    {
                        _context.Entry(section).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(section).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
