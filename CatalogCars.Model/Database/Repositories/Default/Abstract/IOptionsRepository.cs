using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IOptionsRepository
    {
        bool ContainsOption(string name, string ruName);

        bool SaveOption(Option option);

        int GetCountOptions(OptionsFilters filters);

        Option GetOption(Guid id);

        IQueryable<string> GetNamesOptions(string searchString);

        IQueryable<Option> GetOptions(OptionsFilters filters);

        void DeleteOption(Guid id);
    }
}
