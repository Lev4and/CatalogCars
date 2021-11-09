using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISalonsRepository
    {
        bool ContainsSalon(Guid locationId, string name);

        bool SaveSalon(Salon salon);

        int GetCountSalons(SalonsFilters filters);

        Salon GetSalon(Guid id);

        DateTime GetMinRegistrationDate();

        DateTime GetMaxRegistrationDate();

        IQueryable<string> GetNamesSalons(string searchString);

        IQueryable<Salon> GetSalons(SalonsFilters filters);

        void DeleteSalon(Guid id);
    }
}
