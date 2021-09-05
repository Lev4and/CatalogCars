using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IStatePhotosRepository
    {
        bool Save(ref StatePhoto entity);
    }
}
