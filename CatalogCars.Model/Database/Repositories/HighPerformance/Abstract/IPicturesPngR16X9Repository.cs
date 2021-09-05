using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPicturesPngR16X9Repository
    {
        bool Save(ref PicturePngR16x9 entity);
    }
}
