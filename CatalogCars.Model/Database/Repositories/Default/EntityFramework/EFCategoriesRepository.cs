using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFCategoriesRepository : ICategoriesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ICategoriesSorter> _sorters;

        public EFCategoriesRepository(CatalogCarsDbContext context, IEnumerable<ICategoriesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsCategory(string name, string ruName)
        {
            return _context.Categories.FirstOrDefault(category => category.Name == name ||
                category.RuName == ruName) != null;
        }

        public void DeleteCategory(Guid id)
        {
            _context.Categories.Remove(GetCategory(id));
            _context.SaveChanges();
        }

        public IQueryable<Category> GetCategories(CategoriesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Category> categories = _context.Categories
                .Where(category => EF.Functions.Like(category.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                categories = sorter.Sort(categories);
            }

            return categories
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public Category GetCategory(Guid id)
        {
            return _context.Categories
                .AsNoTracking()
                .FirstOrDefault(category => category.Id == id);
        }

        public int GetCountCategories(CategoriesFilters filters)
        {
            return _context.Categories
                .Where(category => EF.Functions.Like(category.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesCategories(string searchString)
        {
            return _context.Categories
                .Where(category => EF.Functions.Like(category.RuName, $"%{searchString}%"))
                .OrderBy(category => category.RuName)
                .Select(category => category.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public bool SaveCategory(Category category)
        {
            if(category.Id == default)
            {
                if(!ContainsCategory(category.Name, category.RuName))
                {
                    _context.Entry(category).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetCategory(category.Id);

                if(currentVersion.Name != category.Name || currentVersion.RuName != category.RuName)
                {
                    if (!ContainsCategory(category.Name, category.RuName))
                    {
                        _context.Entry(category).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(category).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
