using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPhonesRepository
    {
        int GetCountPhones(PhonesFilters filters);

        IQueryable<string> GetNamesPhones(string searchString);

        IQueryable<Phone> GetPhones(PhonesFilters filters);
    }
}
