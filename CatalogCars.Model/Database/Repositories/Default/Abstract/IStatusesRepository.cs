using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IStatusesRepository
    {
        bool ContainsStatus(string name, string ruName);

        bool SaveStatus(Status status);

        int GetCountStatuses(StatusesFilters filters);

        Status GetStatus(Guid id);

        IQueryable<string> GetNamesStatuses(string searchString);

        IQueryable<Status> GetStatuses();

        IQueryable<Status> GetStatuses(StatusesFilters filters);

        void DeleteStatus(Guid id);
    }
}
