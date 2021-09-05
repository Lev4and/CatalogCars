using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IRegionsRepository
    {
        bool Contains(string stringId);

        bool Save(ref RegionInformation entity);

        Guid GetRegionId(string stringId);
    }
}
