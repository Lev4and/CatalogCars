using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPicturesJpegRepository
    {
        bool Save(ref PictureJpeg entity);
    }
}
