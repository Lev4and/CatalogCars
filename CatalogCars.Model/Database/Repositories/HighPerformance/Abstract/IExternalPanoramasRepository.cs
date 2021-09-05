using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IExternalPanoramasRepository
    {
        bool Save(ref ExternalPanorama entity);
    }
}
