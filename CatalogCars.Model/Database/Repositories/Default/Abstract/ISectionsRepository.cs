using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ISectionsRepository
    {
        bool ContainsSection(string name, string ruName);

        bool SaveSection(Section section);

        int GetCountSections(SectionsFilters filters);

        Section GetSection(Guid id);

        IQueryable<string> GetNamesSections(string searchString);

        IQueryable<Section> GetSections();

        IQueryable<Section> GetSections(SectionsFilters filters);

        void DeleteSection(Guid id);
    }
}
