using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Option;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool ContainsOption(string name, string ruName)
        {
            return _context.Options.FirstOrDefault(option => option.Name == name || 
                option.RuName == ruName) != null;
        }

        public void DeleteOption(Guid id)
        {
            _context.Options.Remove(GetOption(id));
            _context.SaveChanges();
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

        public Option GetOption(Guid id)
        {
            return _context.Options
                .AsNoTracking()
                .FirstOrDefault(option => option.Id == id);
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

        public bool SaveOption(Option option)
        {
            if(option.Id == default)
            {
                if (!ContainsOption(option.Name, option.RuName))
                {
                    _context.Entry(option).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetOption(option.Id);

                if(currentVersion.Name != option.Name)
                {
                    if (!ContainsOption(option.Name, option.RuName))
                    {
                        _context.Entry(option).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(option).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
