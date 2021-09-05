using CatalogCars.Model.Database.Entities;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IVinsRepository
    {
        bool Save(ref Vin entity);
    }
}
