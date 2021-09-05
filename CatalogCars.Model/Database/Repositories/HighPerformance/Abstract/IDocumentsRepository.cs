using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IDocumentsRepository
    {
        bool Save(ref Documents entity);
    }
}
