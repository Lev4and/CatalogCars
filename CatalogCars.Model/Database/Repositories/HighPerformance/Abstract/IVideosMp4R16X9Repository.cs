using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVideosMp4R16X9Repository
    {
        bool Save(ref VideoMp4R16x9 entity);
    }
}
