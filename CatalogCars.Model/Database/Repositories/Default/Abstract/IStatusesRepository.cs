using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IStatusesRepository
    {
        int GetCountStatuses(StatusesFilters filters);

        IQueryable<string> GetNamesStatuses(string searchString);

        IQueryable<Status> GetStatuses();

        IQueryable<Status> GetStatuses(StatusesFilters filters);
    }
}
