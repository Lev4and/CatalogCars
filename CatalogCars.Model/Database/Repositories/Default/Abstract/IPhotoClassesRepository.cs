using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPhotoClassesRepository
    {
        bool ContainsPhotoClass(string name, string ruName);

        bool SavePhotoClass(PhotoClass photoClass);

        int GetCountPhotoClasses(PhotoClassesFilters filters);

        PhotoClass GetPhotoClass(Guid id);

        IQueryable<string> GetNamesPhotoClasses(string searchString);

        IQueryable<PhotoClass> GetPhotoClasses(PhotoClassesFilters filters);

        void DeletePhotoClass(Guid id);
    }
}
