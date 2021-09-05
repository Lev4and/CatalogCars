using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVideosH264Repository
    {
        bool Save(ref VideoH264 entity);
    }
}
