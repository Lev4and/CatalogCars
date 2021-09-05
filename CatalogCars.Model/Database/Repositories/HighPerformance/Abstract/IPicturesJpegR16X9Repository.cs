using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPicturesJpegR16X9Repository
    {
        bool Save(ref PictureJpegR16x9 entity);
    }
}
