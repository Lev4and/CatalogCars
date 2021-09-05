using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPicturesWebpR16X9Repository
    {
        bool Save(ref PictureWebpR16x9 entity);
    }
}
