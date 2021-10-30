using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IAvailabilitiesRepository
    {
        bool ContainsAvailability(string name, string ruName);

        bool SaveAvailability(Availability availability);

        int GetCountAvailabilities(AvailabilitiesFilters filters);

        Availability GetAvailability(Guid id);

        IQueryable<string> GetNamesAvailabilities(string searchString);

        IQueryable<Availability> GetAvailabilities();

        IQueryable<Availability> GetAvailabilities(AvailabilitiesFilters filters);

        void DeleteAvailability(Guid id);
    }
}
