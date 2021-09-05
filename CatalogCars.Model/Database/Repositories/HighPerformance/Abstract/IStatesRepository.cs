using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IStatesRepository
    {
        bool Save(ref State entity);
    }
}
