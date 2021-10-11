using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IAvailabilitiesRepository
    {
        int GetCountAvailabilities(AvailabilitiesFilters filters);

        IQueryable<string> GetNamesAvailabilities(string searchString);

        IQueryable<Availability> GetAvailabilities();

        IQueryable<Availability> GetAvailabilities(AvailabilitiesFilters filters);
    }
}
