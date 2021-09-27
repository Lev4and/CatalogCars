using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISalonsRepository
    {
        int GetCountSalons(SalonsFilters filters);

        DateTime GetMinRegistrationDate();

        DateTime GetMaxRegistrationDate();

        IQueryable<string> GetNamesSalons(string searchString);

        IQueryable<Salon> GetSalons(SalonsFilters filters);
    }
}
