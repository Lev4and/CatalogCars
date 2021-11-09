using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ITransmissionsRepository
    {
        bool ContainsTransmission(string name, string ruName);

        bool SaveTransmission(Transmission transmission);

        int GetCountTransmissions(TransmissionsFilters filters);

        Transmission GetTransmission(Guid id);

        IQueryable<string> GetNamesTransmissions(string searchString);

        IQueryable<Transmission> GetTransmissions();

        IQueryable<Transmission> GetTransmissions(TransmissionsFilters filters);

        void DeleteTransmission(Guid id);
    }
}
