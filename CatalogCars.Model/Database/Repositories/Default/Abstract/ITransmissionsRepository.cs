using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ITransmissionsRepository
    {
        int GetCountTransmissions(TransmissionsFilters filters);

        IQueryable<string> GetNamesTransmissions(string searchString);

        IQueryable<Transmission> GetTransmissions();

        IQueryable<Transmission> GetTransmissions(TransmissionsFilters filters);
    }
}
