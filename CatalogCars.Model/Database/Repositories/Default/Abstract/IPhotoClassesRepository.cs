using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPhotoClassesRepository
    {
        int GetCountPhotoClasses(PhotoClassesFilters filters);

        IQueryable<string> GetNamesPhotoClasses(string searchString);

        IQueryable<PhotoClass> GetPhotoClasses(PhotoClassesFilters filters);
    }
}
