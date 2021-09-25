using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ICategoriesRepository
    {
        int GetCountCategories(CategoriesFilters filters);

        IQueryable<string> GetNamesCategories(string searchString);

        IQueryable<Category> GetCategories(CategoriesFilters filters);
    }
}
