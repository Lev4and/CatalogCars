using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPhonesRepository
    {
        bool ContainsPhone(string value);

        bool SavePhone(Phone phone);

        int GetCountPhones(PhonesFilters filters);

        Phone GetPhone(Guid id);

        IQueryable<string> GetNamesPhones(string searchString);

        IQueryable<Phone> GetPhones(PhonesFilters filters);

        void DeletePhone(Guid id);
    }
}
