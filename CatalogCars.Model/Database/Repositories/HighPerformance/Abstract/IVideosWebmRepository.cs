using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVideosWebmRepository
    {
        bool Save(ref VideoWebm entity);
    }
}
