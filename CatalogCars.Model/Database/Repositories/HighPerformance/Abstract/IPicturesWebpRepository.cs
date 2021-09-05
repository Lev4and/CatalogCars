using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPicturesWebpRepository
    {
        bool Save(ref PictureWebp entity);
    }
}
