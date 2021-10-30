using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ICategoriesRepository
    {
        bool ContainsCategory(string name, string ruName);

        bool SaveCategory(Category category);

        int GetCountCategories(CategoriesFilters filters);

        Category GetCategory(Guid id);

        IQueryable<string> GetNamesCategories(string searchString);

        IQueryable<Category> GetCategories(CategoriesFilters filters);

        void DeleteCategory(Guid id);
    }
}
