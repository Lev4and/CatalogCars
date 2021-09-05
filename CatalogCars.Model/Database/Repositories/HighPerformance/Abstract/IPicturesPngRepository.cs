using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPicturesPngRepository
    {
        bool Save(ref PicturePng entity);
    }
}
