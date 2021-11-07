using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPtsTypesRepository
    {
        bool ContainsPtsType(string name, string ruName);

        bool SavePtsType(PtsType ptsType);

        int GetCountPtsTypes(PtsTypesFilters filters);

        PtsType GetPtsType(Guid id);

        IQueryable<string> GetNamesPtsTypes(string searchString);

        IQueryable<PtsType> GetPtsTypes(PtsTypesFilters filters);

        void DeletePtsType(Guid id);
    }
}
