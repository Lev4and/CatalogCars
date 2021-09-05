using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IMarkLogosRepository
    {
        bool Save(ref MarkLogo entity);
    }
}
